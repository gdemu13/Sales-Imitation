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
            var curMission = await currentMissionRepository.GetByUser(currentUser.ID.Value);
            if (curMission != null)
                throw new LocalizableException("user_already_has_mission", "user_already_has_mission");

            var (player, _) = await playerRepository.GetByID(currentUser.ID.Value);
            var category = await categoryRepository.Get(request.SelectedCategoryID);
            var mission = await missionRepository.GetByLevel(player.CurrentLevel);

            var products = await productRepository.GetByCategoryAndPriceRange(category.ID, mission.PriceRange.From, mission.PriceRange.To);
            System.Console.WriteLine("products " + products.Count());
            var randomProduct = ChooseRandomProduct(products);
            var randomProduct2 = ChooseRandomProduct(randomProduct.ConnectedProduct);

            var currentMissionPlayer = new CurrentMissionPlayer(player.ID, $"{player.Firstname} {player.Lastname}",player.CurrentLevel);
System.Console.WriteLine(currentUser.ID.Value);
System.Console.WriteLine(currentMissionPlayer.ID);
            var partner = await partnerRepository.Get(randomProduct.Partner.ID);
            var currentMissionProduct1 = new CurrentMissionProduct(randomProduct.ID, randomProduct.Name, randomProduct.Description, partner.Name, partner.Address.Street, "TODO", randomProduct.Point);
            var currentMissionProduct2 = new CurrentMissionProduct(randomProduct2.ID, randomProduct2.Name, randomProduct2.Description, partner.Name, partner.Address.Street, "TODO", randomProduct2.Point);

            var currentMissionCategory = new CurrentMissionCategory(category.ID, category.Name);
            System.Console.WriteLine("currentMissionCategory " + currentMissionCategory.ID + " " + currentMissionCategory.Name);
            curMission = new CurrentMission(Guid.NewGuid(), currentMissionPlayer, mission.Name, mission.Description, player.CurrentLevel, currentMissionProduct1, currentMissionProduct2, currentMissionCategory, -1);
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