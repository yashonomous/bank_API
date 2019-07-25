# bank_API
 Gives details about various banks given various API parameters.
 Used Postgres as my backend db.
 I have also attached a dump file of my Postgres db for furthur usage.
 
 
My APIs provide below mentioned functionalities-
 1. GET API to fetch a bank details, given branch IFSC code \n
 2.GET API to fetch all details of branches, given bank name and a city \n
 3.Each API supports limit & offset parameters. (I've added default offset and limit, if not provided.) \n
 4.Each API is authenticated using a JWT key, with validity = 5 days  \n
 
