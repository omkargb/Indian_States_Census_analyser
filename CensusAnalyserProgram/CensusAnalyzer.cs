using CensusAnalyserProgram.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace CensusAnalyserProgram
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string,CensusDTO> LoadCensusData(Country country,string csvFilePath,string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }

    }
}
