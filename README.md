# Sales Imitation

![image of dashboard](https://public-v2links.adobecc.com/22865f0b-b7a1-495e-5bab-25e433618ff3/component?params=component_id%3A65e52647-3c8c-452f-a634-fb720a8d9137&params=version%3A3&token=1594923984_da39a3ee_99e9702d36e23554bfef31cf571c52abb0170e06&api_key=CometServer1)

On this website, customers are able to sell products and make money by it. On the last round, they can win the jackpot.

There are 10 rounds and 1 super round on the website. On each round customers are given random products and a deadline to sell them. on every sold product, they earn coins that can be withdrawn and customer will be moved to the next round.
Every next round is harder than previous, because of products price increment, but also they have more time to sell products.

### Playground

You can play on site by this urls:
- http://test.si.ge
- http://admin.test.si.ge
- http://partner.test.si.ge


### Web projects and environments

There are two environments:  one for staging - [test.si.ge](http://test.si.ge) and second for production - [si.ge](http://si.ge).

The solution contains three web projects:

1. - the main website where customers can register and participate. http://test.si.ge
> - api: https://github.com/gmaza/Sales-Imitation/tree/master/SalesImitation/src/presenter/SI.web
> - clientApp: https://github.com/gmaza/Sales-Imitation/tree/master/SalesImitation/src/presenter/SI.web/ClientApp


2. - an admin panel where an administrator can administrate the main website and get reports. http://admin.test.si.ge
> - api: https://github.com/gmaza/Sales-Imitation/tree/master/SalesImitation/src/presenter/SI.administration.web
> - clientApp: https://github.com/gmaza/Sales-Imitation/tree/master/SalesImitation/src/presenter/SI.administration.web/clientApp


3. - the website for partners, where they can confirm product sales. http://partner.test.si.ge
> - api: https://github.com/gmaza/Sales-Imitation/tree/master/SalesImitation/src/presenter/SI.partner.web
> - clientApp: https://github.com/gmaza/Sales-Imitation/tree/master/SalesImitation/src/presenter/SI.partner.web/clientApp


### Coding Guidelines

#### Architecture and design patterns
* We use Uncle Bob's Clean Architecture
* CQRS
* mediator pattern (using Mediatr library)
* repository pattern
* dependency injection
* optimistic locking
* domain event pattern
(all code should be mockable and testable)
#### Languages, frameworks, db
* dotnet core 3.X with C# for backend
* mssql as db
* vue.js for frontend
* vuetify as frontend component library
* dapper as orm
* serilog for logging
#### cli, package managers
dotnet cli
vue cli
npm for frontend package manager
nuget for backend package manager

## Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

#### Build and run commands
before build or run backend, make sure you have changed values of appsettings.json file.

* to run backend:
```
dotnet watch run
```
* to run frotend application:
```
npm run serve
```
* to publish frontend applciation
```
npm run build
```
this command automaticaly builds client project and copies it into backend folder - wwwroot

