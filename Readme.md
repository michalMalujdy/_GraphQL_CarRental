# GraphQL + Clean Architecture Demo

## Overview
Proof of Concept utilizing GraphQL in a basic application with the combination of [Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture). The business context of the application is a car renting system that allows basic CRUD operations on a Car and a Rental. There are two Web interfaces to interact with the system - GraphQL and RESTful API, which are roughly equivalent in offered features.

It so happens, that in my opinion, Clean Architecture encapsulates and isolates application and domain logic so well, that any plug-in external interface, such as Web GraphlQL or Web RESTful API is easily applicable to the Core (Application + Domain logic) of the application. Because all the business logic is encapsulated inside of the Core, Web GraphQL and Web Restful API interfaces reuses the same features but through two different media. Also the code of both of those Web interfaces focuses only on providing those interfaces without any business logic being leaked or dependant upon the Web layer.

## Demo
[![Demo](https://i.ibb.co/0hCsVFk/graphql-demo-thumbnail.jpg)](https://youtu.be/J7aa51_PmcM "Demo")


## Technology stack
- ASP.NET 5
- GraphQL (ChilliCream Hot Chocolate)