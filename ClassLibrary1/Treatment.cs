using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalProjectConstruction
{
    public class Treatment
    {
        public DateTime DateTime { get; set; }
        public string TrayNo { get; set; }
        public string Notes { get; set; }
        public string WorkParamsSHA { get; set; }
        public string WorkParamsSignature { get; set; }
        public string ProjectGUID { get; set; }
        public string ProjectUniqueID { get; set; }
        public List<Tooth> Teeth { get; set; }
        public Practice Practice { get; set; }
        public Patient Patient { get; set; }
        public DateTime DentalDBBuildDate { get; set; }
        public string DentalDBProductName { get; set; }
        public string ToothColor { get; set; }
        public string AntagonistType { get; set; }
    }
    public class Tooth
    {
        public string Number { get; set; }
        public string ReconstructionType { get; set; }
        public string MesialConnector { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string MaterialName { get; set; }
        public string Material { get; set; }
        public string ImplantType { get; set; }
        public string MaterialAbutment { get; set; }
        public string ScanAbutmentScan { get; set; }
        public string PreparationType { get; set; }
        public string SituScan { get; set; }
        public string SeparateGingivaScan { get; set; }
        public string Color { get; set; }
    }
    public class Parameter
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public double StepSize { get; set; }
    }
    public class Practice
    {
        public int PracticeId { get; set; }
        public string PracticeName { get; set; }
    }
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientFirstName { get; set; }
    }
}
