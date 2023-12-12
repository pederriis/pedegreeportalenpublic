using System;
using System.Collections.Generic;
using System.Text;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.Disease
{
   public class DiseaseId: Value<DiseaseId>
    {
        
        public DiseaseId(Guid value) => Value = value;

        public Guid Value { get; internal set; }

        protected DiseaseId() { }

        public static implicit operator Guid(DiseaseId self) => self.Value;

        public static implicit operator DiseaseId(string value) => new DiseaseId(Guid.Parse(value));

        public override string ToString() => Value.ToString();
    }
}

