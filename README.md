# moneybox

Project Test Moneybox - READ ME

1 - This project is using ASP.NET MVC 5, Entity Framework and SQL Server to create, update, delete and get all informations about the transaction.
2 - Also it was used code first to create the database. Before you run the application you'll need to create a database called MoneyboxDb locally using the instance .\SqlExpress and that's it, when you run the application or try to call a method it'll create the database automatically.
3 - It was created a REST project and a Unit test using Mock structure to validade the requirements of Delete and Update that need some some rules of business.
4 - To call the methos of the REST API you have the following calls:
	A - GET method transaction: You need to pass one parameter of type integer as a Transaction Id and.
		Link: http://localhost:61720/api/Transaction/{IdParameter}
	B - GET method list of transactions: You don't need to pass any parameter.
		Link: http://localhost:61720/api/Transaction
	C - DELETE method: Delete transaction: You need to pass one parameter of type integer as a Transaction Id.
		Link: http://localhost:61720/api/Transaction/{IdParameter}
	D - POST method: Create Transaction: You need to pass an object of type Transaction with the following attributes:
			- TransactionDate - Datetime
			- Description - Lenght = 300
			- TransactionAmount - Decimal
			- CurrencyCode - String
			- Merchant - Length = 100 
		Link: http://localhost:61720/api/Transaction + object
	E - PUT method: Update Transaction:	
			- TransactionDate - Datetime		
			- Description - Lenght = 300
			- TransactionAmount - Decimal
			- CurrencyCode - String
			- Merchant - Length = 100
		Link: http://localhost:61720/api/Transaction + object
4 - I started to develop at 3:29 PM and finish at 7:23 and took a while to put in the github.
