# Content Platform Practical exercise 

Hello, we are the Farfetch Content Platform team, and we propose that you make a small exercise to help us better understand your current skills.
With this in mind, we propose that you do the following: 

1. Create a `REST API` that allows to perform `CRUD` operations on a specific entity;
2. The entity that we will be working with is the `Product` entity;
3. The system supports three different types of products: `Drink`, `Food`, `Clothing`;
4. Each product has a price and quantity associated;
5. You will have to store attributes like the capacity of a bottle or the weight of the food. ( For instance, a wine bottle may contain 0,75cl of wine and a can of tuna may weight 120g);
6. Clothing products have the size associated;
7. When we retrieve products with our Rest API each product needs to contain a `FinalPrice` property;
8. `FinalPrice = Price * Quantity + (Price * Type Tax) (Type Tax: Drink - 0,05, Food: 0,06, Clothing: 0,07)`.
9. The API should be able to answer the following query: `Give me all the products that have stock and the final price is between 100 and 500`


Don't know how to start?  Open a new terminal and type: `dotnet new webapi`

# Requirements

1. The exercise must be done using C#;
2. Any database of choice (can be in memory database using C# objects);
3. This exercise must be done in a public github repository;
4. Send the completed exercise to your Farfetch contact resposible for your application.
