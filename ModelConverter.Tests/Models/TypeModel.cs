using ModelConverter.Interfaces;

namespace ModelConverter.Tests.Models {
    public class TypeModel : IModelToConvert
    {
        public string Name { get; set; } = @"Jeroen";

        public int Number { get; set; } = 1337;

        public double Decimal {get;set;} = 1.47;

        public bool Value { get; set; } = true;

        public char Char{get;set;} = 'a';
    }
}