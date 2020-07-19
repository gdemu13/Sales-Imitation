using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SI.Common.Models;
using SI.Domain.Abstractions.Repositories;
using SI.Domain.Entities;
using SI.Domain.Exceptions;
using SI.Domin.Abstractions.Authentication;

namespace SI.Application.CurrentMissions
{
    public class StartNewMissionHandler : IRequestHandler<StartNewMissionRequest, Result>
    {
        private readonly ICurrentUser currentUser;
        private readonly IPlayerRepository playerRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IMissionRepository missionRepository;
        private readonly IPartnerRepository partnerRepository;
        private readonly IProductRepository productRepository;
        private readonly ICurrentMissionRepository currentMissionRepository;

        public StartNewMissionHandler(ICurrentUser currentUser, IPlayerRepository playerRepository,
                                                                ICategoryRepository categoryRepository,
                                                                IMissionRepository missionRepository,
                                                                IPartnerRepository partnerRepository,
                                                                IProductRepository productRepository,
                                                                ICurrentMissionRepository currentMissionRepository)
        {
            this.currentUser = currentUser;
            this.playerRepository = playerRepository;
            this.categoryRepository = categoryRepository;
            this.missionRepository = missionRepository;
            this.partnerRepository = partnerRepository;
            this.productRepository = productRepository;
            this.currentMissionRepository = currentMissionRepository;
        }

        public async Task<Result> Handle(StartNewMissionRequest request, CancellationToken token)
        {
            var (curMission, _) = await currentMissionRepository.GetActiveByUser(currentUser.ID.Value);
            if (curMission != null)
                throw new LocalizableException("user_already_has_current_mission", "მომხამრებელს უკვე დაწყებუ");

            var (player, _) = await playerRepository.GetByID(currentUser.ID.Value);

            //get category that is chosen by player
            var category = await categoryRepository.Get(request.SelectedCategoryID);
            if (category == null)
                throw new LocalizableException("invalid_category_is_selected", "არასწორი კატეგორია არის არჩეული");

            //get mission that player should start
            var mission = await missionRepository.GetByLevel(player.CurrentLevel);

            //get products by mission price range and choose two connected from them.
            var products = await productRepository.GetByCategoryAndPriceRange(category.ID, mission.PriceRange.From, mission.PriceRange.To);
            var randomProduct = ChooseRandomProduct(products);
            var randomProduct2 = ChooseRandomProduct(randomProduct.ConnectedProduct);

            //create new current mission, generate promo code and start
            var currentMissionPlayer = new CurrentMissionPlayer(player.ID, $"{player.Firstname} {player.Lastname}", player.CurrentLevel);
            var partner = await partnerRepository.Get(randomProduct.Partner.ID);
            var currentMissionProduct1 = new CurrentMissionProduct(randomProduct.ID, randomProduct.Price.Amount, randomProduct.Name, randomProduct.Description,
                                                                    partner.Name, partner.ID, randomProduct.Images.FirstOrDefault()?.Url, partner.Address.Street,
                                                                    randomProduct.Gift, randomProduct.Coin);

            var currentMissionProduct2 = new CurrentMissionProduct(randomProduct2.ID, randomProduct2.Price.Amount, randomProduct2.Name, randomProduct2.Description,
                                                                     partner.Name, partner.ID, randomProduct2.Images.FirstOrDefault()?.Url, partner.Address.Street,
                                                                     randomProduct2.Gift, randomProduct2.Coin);

            var currentMissionCategory = new CurrentMissionCategory(category.ID, category.Name);

            curMission = new CurrentMission(Guid.NewGuid(),
                                            currentMissionPlayer,
                                            mission.Name,
                                            mission.Description,
                                            player.CurrentLevel,
                                            currentMissionProduct1,
                                            currentMissionProduct2,
                                            currentMissionCategory,
                                            mission.DurationInHours);

            curMission.GenerateNewpromoCode();
            curMission.Start(DateTime.Now);

            return await currentMissionRepository.Insert(curMission);
        }

        private T ChooseRandomProduct<T>(IEnumerable<T> products)
        {
            Random rand = new Random();
            return products.ToList()[rand.Next(0, products.Count() - 1)];
        }
    }
}