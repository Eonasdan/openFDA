namespace OpenFDA.Drug.Label
{
	public class PaginationOptions
	{
        /// <summary>
        /// API default is 1 max is 99
        /// </summary>
	    public int Limit { get; set; } = 1;
		public int Skip { get; set; }
	}
}