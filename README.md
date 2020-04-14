# tax-calculator-api
I have created a REST API in [ASP.NET Core]([https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)) to calculate taxes in North Carolina. Once launched, the API can be accessed via [https://localhost:5001/api/v1/taxCalculator](https://localhost:5001/api/v1/taxCalculator).

## Running
The application can be launched once [ASP.NET Core]([https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) has been installed. Once installed and added to path environment variable, publish the application by navigating to the base directory of the project and run the following command:

`dotnet publish`

 The application may be run by navigating to the `TaxCalculator/bin/Debug` or `TaxCalculator/bin/Release` folder and entering the following command:

`dotnet TaxCalculator.dll`
## API
The api has a single `GET` endpoint. It takes in two parameters:
`price`: Must be sent as a floating point number type, do not surround in quotes ie. `4.25`
`zipCode`: Must be sent as a 5 digit number ie. `92957`

Both `price` and `zipCode` are required.
#### Success
If successful, a response would look like this:
```
{
	"originalPrice":  1,
	"fullPrice":  1.07,
	"taxRate":  0.07
}
```
`originalPrice`: The original price of the item purchased.
`fullPrice`: The price with tax factored in.
`taxRate`: The tax rate of the zip code entered

#### Error
If there is an error, the response would look like this:
```
{
	"errorMessage":  "Zip code [2890] is invalid, must be 5 digits."
}
```
`errorMessage`: The description of the error.
In this case, we gave it an invalid zip code.

## Final notes
There were a few different options I was debating over on how to make this the easiest to launch for conveniance. I was going to set up a docker container for the API and a docker container for the database as well but I decided against it because I think your machines would more likely have .NET stack installed over Docker.