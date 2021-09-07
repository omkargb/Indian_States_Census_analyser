using CensusAnalyserProgram;
using CensusAnalyserProgram.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static CensusAnalyserProgram.CensusAnalyzer;

namespace CensusAnalyserTest
{
    public class UnitTests
    {

        static string indianStateCensusHeaders = @"State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"G:\BRIDGELABZ\Indian_States_Census_analyser\CensusAnalyserProgram\CSVFiles\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"G:\BRIDGELABZ\Indian_States_Census_analyser\CensusAnalyserProgram\CSVFiles\WrongIndiaStateCensusData.csv";
        static string delimeterIndianCensusFilePath = @"G:\BRIDGELABZ\Indian_States_Census_analyser\CensusAnalyserProgram\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"G:\BRIDGELABZ\Indian_States_Census_analyser\CensusAnalyserProgram\CSVFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianCensusFileType = @"G:\BRIDGELABZ\Indian_States_Census_analyser\CensusAnalyserProgram\CSVFiles\IndiaStateCensusData.txt";

        CensusAnalyserProgram.CensusAnalyzer censusAnalyzer;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyzer = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        //Use case - 1
        //Happy Test Case : the records are checked
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case : to verify if the exception is raised.
        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(37, totalRecord.Count);
        }

        //Sad Test Case : if the type is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileTypeWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongIndianCensusFileType, indianStateCensusHeaders);

            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case : if the file delimiter is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileDelimeterWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, delimeterIndianCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        //Sad Test Case : if the header is incorrect then exception is raised.
        [Test]
        public void GivenIndianCensusDataFileCsvHeaderWrong_WhenRead_ShouldReturnException()
        {
            totalRecord = censusAnalyzer.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(29, totalRecord.Count);
        }

    }
}