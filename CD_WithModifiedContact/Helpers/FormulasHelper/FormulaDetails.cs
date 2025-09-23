namespace CD_WithModifiedContact.Helpers
{
    public struct FormulaDetails
    {
        public string Description { get; set; }
        public string Notation { get; set; }
        public decimal Result { get; set; }

        public FormulaDetails(string description, string notation, decimal result)
        {
            Description = description;
            Notation = notation;
            Result = result;
        }
    }
}
