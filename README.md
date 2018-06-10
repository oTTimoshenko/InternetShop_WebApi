# InternetShop_WebApi
Used technologies: ASP.NET WebAPI 2.0, Entity Framework 6, LINQ, Ninject, AutoMapper, NUnit, Moq. 
This project it is API for online shop which implement main functionality of the online store.
In this project implement Three Layer architecture (with isolation Unit of Work and Repositories in separate project), 
on each level of architecture created own entities (For mapping this entities used AutoMapper)
and Ninject for implementation Dependency Inversion. 
Used design patterns such as: DRY, KISS, YUGNI, Unit of Work and Repositories.
Also there realized the minimal functionality of user authentication and authorization using ASP.NET Identity on cookies based.
