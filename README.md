# bank_API
 Gives details about various banks given various API parameters.<br/>
 
 Used Postgres as my backend db.<br/>
 
 I have also attached a dump file of my Postgres db for furthur usage.<br/>
 
 
My APIs provide below mentioned functionalities-<br/>

1. GET API to fetch a bank details, given branch IFSC code<br/>

2. GET API to fetch all details of branches, given bank name and a city<br/>

3. Each API supports limit & offset parameters. (I've added default offset and limit, if not provided.)<br/>

4. Each API is authenticated using a JWT key, with validity = 5 days<br/>
 
