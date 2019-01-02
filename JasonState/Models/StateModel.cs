namespace JasonState.Models
{
    internal class StateModel
    {
        public string Namespace { get; set; }

        public string Name { get; set; }

        public NextState[] NextState { get; set; }

        public string ErrorState { get; set; }
    }
}