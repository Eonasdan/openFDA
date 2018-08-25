# Open FDA
.NET client for Open FDA APIs

## Usage
```csharp
using OpenFDA.Drug;
using OpenFDA.Drug.Label;

using (var client = new DrugClient(APIKey)) //api key is optional new DrugClient()
{
	var searchResult = await client.SearchAsync(new SearchOptions //search for drugs that cause drowsiness when used
	{
	    WhenUsing = "drowsiness"
	});
}
```
## Notes

* Current this wrapper only supports the Drug Label api. I welcome commits to add the other apis and I may get time to add them myself.
* The government is not particular great at developing apis that follow modern standards and this one is no different. 
Searching multiple fields is possible according to the docs however I experienced a lot of issues with this. 
The docs also specific that certain search fields are an “array of string” even though all search fields are put in the query string. 
Please let me know as you find cases that do not work for you so I can try them out myself.


## References
 - [Open FDA's documentation](https://open.fda.gov/apis/)
