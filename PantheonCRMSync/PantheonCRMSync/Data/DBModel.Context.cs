﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PantheonCRMSync.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int OS_StrnPost(string costDrv, string name, string classif, string consignee, string dept, ObjectParameter qId, ObjectParameter error)
        {
            var costDrvParameter = costDrv != null ?
                new ObjectParameter("CostDrv", costDrv) :
                new ObjectParameter("CostDrv", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var classifParameter = classif != null ?
                new ObjectParameter("Classif", classif) :
                new ObjectParameter("Classif", typeof(string));
    
            var consigneeParameter = consignee != null ?
                new ObjectParameter("Consignee", consignee) :
                new ObjectParameter("Consignee", typeof(string));
    
            var deptParameter = dept != null ?
                new ObjectParameter("Dept", dept) :
                new ObjectParameter("Dept", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OS_StrnPost", costDrvParameter, nameParameter, classifParameter, consigneeParameter, deptParameter, qId, error);
        }
    
        public virtual int OS_SubjektPost(string subjectId, string name2, string address, string post, string country, string code, string regNo, string buyer, string wayOfSale, string currency, string supplier, string suppSaleMet, string suppCurr, ObjectParameter qId, ObjectParameter error)
        {
            var subjectIdParameter = subjectId != null ?
                new ObjectParameter("SubjectId", subjectId) :
                new ObjectParameter("SubjectId", typeof(string));
    
            var name2Parameter = name2 != null ?
                new ObjectParameter("Name2", name2) :
                new ObjectParameter("Name2", typeof(string));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var postParameter = post != null ?
                new ObjectParameter("Post", post) :
                new ObjectParameter("Post", typeof(string));
    
            var countryParameter = country != null ?
                new ObjectParameter("Country", country) :
                new ObjectParameter("Country", typeof(string));
    
            var codeParameter = code != null ?
                new ObjectParameter("Code", code) :
                new ObjectParameter("Code", typeof(string));
    
            var regNoParameter = regNo != null ?
                new ObjectParameter("RegNo", regNo) :
                new ObjectParameter("RegNo", typeof(string));
    
            var buyerParameter = buyer != null ?
                new ObjectParameter("Buyer", buyer) :
                new ObjectParameter("Buyer", typeof(string));
    
            var wayOfSaleParameter = wayOfSale != null ?
                new ObjectParameter("WayOfSale", wayOfSale) :
                new ObjectParameter("WayOfSale", typeof(string));
    
            var currencyParameter = currency != null ?
                new ObjectParameter("Currency", currency) :
                new ObjectParameter("Currency", typeof(string));
    
            var supplierParameter = supplier != null ?
                new ObjectParameter("Supplier", supplier) :
                new ObjectParameter("Supplier", typeof(string));
    
            var suppSaleMetParameter = suppSaleMet != null ?
                new ObjectParameter("SuppSaleMet", suppSaleMet) :
                new ObjectParameter("SuppSaleMet", typeof(string));
    
            var suppCurrParameter = suppCurr != null ?
                new ObjectParameter("SuppCurr", suppCurr) :
                new ObjectParameter("SuppCurr", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OS_SubjektPost", subjectIdParameter, name2Parameter, addressParameter, postParameter, countryParameter, codeParameter, regNoParameter, buyerParameter, wayOfSaleParameter, currencyParameter, supplierParameter, suppSaleMetParameter, suppCurrParameter, qId, error);
        }
    
        public virtual int OS_FakturaPost(string cRMDocumentId, string docType, string date, string receiver, string currency, Nullable<decimal> fXRate, string doc1, string dateDoc1, string dateVAT, string dateDue, ObjectParameter error, ObjectParameter kljuc)
        {
            var cRMDocumentIdParameter = cRMDocumentId != null ?
                new ObjectParameter("CRMDocumentId", cRMDocumentId) :
                new ObjectParameter("CRMDocumentId", typeof(string));
    
            var docTypeParameter = docType != null ?
                new ObjectParameter("DocType", docType) :
                new ObjectParameter("DocType", typeof(string));
    
            var dateParameter = date != null ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(string));
    
            var receiverParameter = receiver != null ?
                new ObjectParameter("Receiver", receiver) :
                new ObjectParameter("Receiver", typeof(string));
    
            var currencyParameter = currency != null ?
                new ObjectParameter("Currency", currency) :
                new ObjectParameter("Currency", typeof(string));
    
            var fXRateParameter = fXRate.HasValue ?
                new ObjectParameter("FXRate", fXRate) :
                new ObjectParameter("FXRate", typeof(decimal));
    
            var doc1Parameter = doc1 != null ?
                new ObjectParameter("Doc1", doc1) :
                new ObjectParameter("Doc1", typeof(string));
    
            var dateDoc1Parameter = dateDoc1 != null ?
                new ObjectParameter("DateDoc1", dateDoc1) :
                new ObjectParameter("DateDoc1", typeof(string));
    
            var dateVATParameter = dateVAT != null ?
                new ObjectParameter("DateVAT", dateVAT) :
                new ObjectParameter("DateVAT", typeof(string));
    
            var dateDueParameter = dateDue != null ?
                new ObjectParameter("DateDue", dateDue) :
                new ObjectParameter("DateDue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OS_FakturaPost", cRMDocumentIdParameter, docTypeParameter, dateParameter, receiverParameter, currencyParameter, fXRateParameter, doc1Parameter, dateDoc1Parameter, dateVATParameter, dateDueParameter, error, kljuc);
        }
    
        public virtual int OS_RacunDobavljacaPost(string cRMDocumentId, string docType, string date, string issuer, string currency, Nullable<decimal> fXRate, string doc1, string dateDoc1, string dateVAT, string dateDue, ObjectParameter error, ObjectParameter kljuc)
        {
            var cRMDocumentIdParameter = cRMDocumentId != null ?
                new ObjectParameter("CRMDocumentId", cRMDocumentId) :
                new ObjectParameter("CRMDocumentId", typeof(string));
    
            var docTypeParameter = docType != null ?
                new ObjectParameter("DocType", docType) :
                new ObjectParameter("DocType", typeof(string));
    
            var dateParameter = date != null ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(string));
    
            var issuerParameter = issuer != null ?
                new ObjectParameter("Issuer", issuer) :
                new ObjectParameter("Issuer", typeof(string));
    
            var currencyParameter = currency != null ?
                new ObjectParameter("Currency", currency) :
                new ObjectParameter("Currency", typeof(string));
    
            var fXRateParameter = fXRate.HasValue ?
                new ObjectParameter("FXRate", fXRate) :
                new ObjectParameter("FXRate", typeof(decimal));
    
            var doc1Parameter = doc1 != null ?
                new ObjectParameter("Doc1", doc1) :
                new ObjectParameter("Doc1", typeof(string));
    
            var dateDoc1Parameter = dateDoc1 != null ?
                new ObjectParameter("DateDoc1", dateDoc1) :
                new ObjectParameter("DateDoc1", typeof(string));
    
            var dateVATParameter = dateVAT != null ?
                new ObjectParameter("DateVAT", dateVAT) :
                new ObjectParameter("DateVAT", typeof(string));
    
            var dateDueParameter = dateDue != null ?
                new ObjectParameter("DateDue", dateDue) :
                new ObjectParameter("DateDue", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OS_RacunDobavljacaPost", cRMDocumentIdParameter, docTypeParameter, dateParameter, issuerParameter, currencyParameter, fXRateParameter, doc1Parameter, dateDoc1Parameter, dateVATParameter, dateDueParameter, error, kljuc);
        }
    
        public virtual int OS_FakturaPozPost(string documentId, Nullable<int> no, string ident, Nullable<decimal> qty, Nullable<decimal> price, string dept, string costDrv, ObjectParameter error)
        {
            var documentIdParameter = documentId != null ?
                new ObjectParameter("DocumentId", documentId) :
                new ObjectParameter("DocumentId", typeof(string));
    
            var noParameter = no.HasValue ?
                new ObjectParameter("No", no) :
                new ObjectParameter("No", typeof(int));
    
            var identParameter = ident != null ?
                new ObjectParameter("Ident", ident) :
                new ObjectParameter("Ident", typeof(string));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("Qty", qty) :
                new ObjectParameter("Qty", typeof(decimal));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var deptParameter = dept != null ?
                new ObjectParameter("Dept", dept) :
                new ObjectParameter("Dept", typeof(string));
    
            var costDrvParameter = costDrv != null ?
                new ObjectParameter("CostDrv", costDrv) :
                new ObjectParameter("CostDrv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OS_FakturaPozPost", documentIdParameter, noParameter, identParameter, qtyParameter, priceParameter, deptParameter, costDrvParameter, error);
        }
    
        public virtual int OS_RacunDobavljacaPozPost(string documentId, Nullable<int> no, string ident, Nullable<decimal> qty, Nullable<decimal> price, string dept, string costDrv, ObjectParameter error)
        {
            var documentIdParameter = documentId != null ?
                new ObjectParameter("DocumentId", documentId) :
                new ObjectParameter("DocumentId", typeof(string));
    
            var noParameter = no.HasValue ?
                new ObjectParameter("No", no) :
                new ObjectParameter("No", typeof(int));
    
            var identParameter = ident != null ?
                new ObjectParameter("Ident", ident) :
                new ObjectParameter("Ident", typeof(string));
    
            var qtyParameter = qty.HasValue ?
                new ObjectParameter("Qty", qty) :
                new ObjectParameter("Qty", typeof(decimal));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var deptParameter = dept != null ?
                new ObjectParameter("Dept", dept) :
                new ObjectParameter("Dept", typeof(string));
    
            var costDrvParameter = costDrv != null ?
                new ObjectParameter("CostDrv", costDrv) :
                new ObjectParameter("CostDrv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OS_RacunDobavljacaPozPost", documentIdParameter, noParameter, identParameter, qtyParameter, priceParameter, deptParameter, costDrvParameter, error);
        }
    }
}