Simple dot net core MVC Application to create category and Product. 
I have used repository Pattern where Unit of work us being used for CRUD operation. Also Identity and role is available to assign. 
Any user can assign any role to theirselves when they create an account ( this is not best practice, however this is just for a test). 

there are 4 user roles. I have only use admin and customer role. Admin can see all products and can add and remove product. 
when user logged in as a customer, user will only see the list of the product available. Customer can't access the category and can not add product and category.

all with the help of Entity Framework core. 
