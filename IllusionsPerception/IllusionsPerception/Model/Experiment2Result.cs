//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IllusionsPerception.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Experiment2Result
    {
        public int Id { get; set; }
        public int Id_User { get; set; }
        public string TesteeResponse { get; set; }
        public string CorrectAnswer { get; set; }
        public int Confidence { get; set; }
        public int NumberDisplay { get; set; }
        public int AllNumberDisplay { get; set; }
    
        public virtual User User { get; set; }
    }
}