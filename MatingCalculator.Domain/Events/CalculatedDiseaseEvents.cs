using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
   public class CalculatedDiseaseEvents
    { 
     public class CreateCalculatedDisease
        {
        public Guid CalculatedDiseaseId { get; set; }
        public Guid MatingCalculationId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Probability { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class UpdateCalculatedDisease
        {
        public Guid CalculatedDiseaseId { get; set; }
        public Guid MatingCalculatiodId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public double Probability { get; set; }
    }

    public class DeleteCalculatedDisease
        {
        public Guid CalculatedDiseaseId { get; set; }
        public bool IsDeleted { get; set; }
    }
    }
}
