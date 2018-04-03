using Sushi.Interfaces;

namespace Sushi.TestModels
{
    /// <summary>
    ///     A representation of the basic types in the <see cref="TypeModel"/>.
    /// </summary>
    public class TypeModel : IScriptModel
    {
        /// <summary>
        ///     What <see cref="Name"/> does this <see cref="TypeModel"/> have?
        /// </summary>
        public string Name { get; set; } = @"Jeroen";

        /// <summary>
        ///     What <see cref="Number"/> does this <see cref="TypeModel"/> have?
        /// </summary>
        public int Number { get; set; } = 1337;

        /// <summary>
        ///     What <see cref="Decimal"/> does this <see cref="TypeModel"/> have?
        /// </summary>
        public double Decimal { get; set; } = 1.47;

        /// <summary>
        ///     What <see cref="Value"/> does this <see cref="TypeModel"/> have?
        /// </summary>
        public bool Value { get; set; } = true;

        /// <summary>
        ///     What <see cref="Char"/> does this <see cref="TypeModel"/> have?
        /// </summary>
        public char Char { get; set; } = 'a';
    }
}