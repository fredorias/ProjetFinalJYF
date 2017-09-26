using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper.WCF
{
    [ServiceContract]
    public interface IRepositoryService1
    {
        [OperationContract]
        string getQueryDescription(string name);
        [OperationContract]
        bool AddNewQuery(WebScraper.WCF.QueryContract query);
        [OperationContract]
        QueryContract GetQueryContractByName(string queryName);
        [OperationContract]
        List<QueryContract> GetAllQueryContract();
        [OperationContract]
        int SaveResults(ResultsHeaderContract rHC, List<ResultsDetailContract> listRDC);
        [OperationContract]
        List<PageContract> GetPageContractById(string QueryId);
        [OperationContract]
        List<SelectorContract> GetSelectorContractById(string PageId);
        [OperationContract]
        ResultsHeaderContract GetSelectorResults(SelectorContract selector);
        [OperationContract]
        List<ResultsDetailContract> GetSelectorResultsDetails(SelectorContract selector);
        [OperationContract]
        void DeleteQuery(QueryContract q);
    }
}



/*
    [ServiceContract]
    public interface IRepository
    {
        [OperationContract]
        string TestServer();

        [OperationContract]
        bool AddNewQuery(string name, string description, string url, string script, DateTime expiry, DateTime timestamp);

        [OperationContract]
        List<Query> getQueryByName(string name);
        [OperationContract]
        List<Query> getAllQuery();
        [OperationContract]
        void ModifyQuery(Query query);
        [OperationContract]
        void DeleteQuery(Query query);
        [OperationContract]
        bool CheckExistingQuery(Query query);
        //get results details
        [OperationContract]
        List<string> GetResults(Query query);
        [OperationContract]
        void SetResults(Query query, string scrapingResults);

*/
