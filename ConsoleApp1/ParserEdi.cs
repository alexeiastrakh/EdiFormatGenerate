using System.Xml.Serialization;

[XmlRoot(ElementName = "partnerID")]
	public class PartnerID
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "roleType")]
		public string RoleType { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "participatingParty")]
	public class ParticipatingParty
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName = "roleType")]
		public string RoleType { get; set; }
		[XmlAttribute(AttributeName = "participationCode")]
		public string ParticipationCode { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "shipTo")]
	public class ShipTo
	{
		[XmlAttribute(AttributeName = "personPlaceID")]
		public string PersonPlaceID { get; set; }
	}

	[XmlRoot(ElementName = "billTo")]
	public class BillTo
	{
		[XmlAttribute(AttributeName = "personPlaceID")]
		public string PersonPlaceID { get; set; }
	}

	[XmlRoot(ElementName = "customer")]
	public class Customer
	{
		[XmlAttribute(AttributeName = "personPlaceID")]
		public string PersonPlaceID { get; set; }
	}

	[XmlRoot(ElementName = "invoiceTo")]
	public class InvoiceTo
	{
		[XmlAttribute(AttributeName = "personPlaceID")]
		public string PersonPlaceID { get; set; }
	}

	[XmlRoot(ElementName = "packListData")]
	public class PackListData
	{
		[XmlElement(ElementName = "packslipTemplate")]
		public string PackslipTemplate { get; set; }
	}

	[XmlRoot(ElementName = "poHdrData")]
	public class PoHdrData
	{
		[XmlElement(ElementName = "packListData")]
		public PackListData PackListData { get; set; }
		[XmlElement(ElementName = "custOrderNumber")]
		public string CustOrderNumber { get; set; }
		[XmlElement(ElementName = "poTypeCode")]
		public string PoTypeCode { get; set; }
		[XmlElement(ElementName = "vendorMessage")]
		public string VendorMessage { get; set; }
		[XmlElement(ElementName = "merchandiseTypeCode")]
		public string MerchandiseTypeCode { get; set; }
		[XmlElement(ElementName = "buyer")]
		public string Buyer { get; set; }
		[XmlElement(ElementName = "offerCurrency")]
		public string OfferCurrency { get; set; }
		[XmlElement(ElementName = "freightPaymentTermsCode")]
		public string FreightPaymentTermsCode { get; set; }
		[XmlElement(ElementName = "salesAgent")]
		public string SalesAgent { get; set; }
		[XmlElement(ElementName = "busRuleCode")]
		public string BusRuleCode { get; set; }
	}

	[XmlRoot(ElementName = "poLineData")]
	public class PoLineData
	{
		[XmlElement(ElementName = "lineReqDelvDate")]
		public string LineReqDelvDate { get; set; }
	}

	[XmlRoot(ElementName = "lineItem")]
	public class LineItem
	{
		[XmlElement(ElementName = "lineItemId")]
		public string LineItemId { get; set; }
		[XmlElement(ElementName = "orderLineNumber")]
		public string OrderLineNumber { get; set; }
		[XmlElement(ElementName = "merchantLineNumber")]
		public string MerchantLineNumber { get; set; }
		[XmlElement(ElementName = "qtyOrdered")]
		public string QtyOrdered { get; set; }
		[XmlElement(ElementName = "unitOfMeasure")]
		public string UnitOfMeasure { get; set; }
		[XmlElement(ElementName = "UPC")]
		public string UPC { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "merchantSKU")]
		public string MerchantSKU { get; set; }
		[XmlElement(ElementName = "vendorSKU")]
		public string VendorSKU { get; set; }
		[XmlElement(ElementName = "unitCost")]
		public string UnitCost { get; set; }
		[XmlElement(ElementName = "shippingCode")]
		public string ShippingCode { get; set; }
		[XmlElement(ElementName = "poLineData")]
		public PoLineData PoLineData { get; set; }
		[XmlElement(ElementName = "expectedShipDate")]
		public string ExpectedShipDate { get; set; }
	}

	[XmlRoot(ElementName = "personPlace")]
	public class PersonPlace
	{
		[XmlElement(ElementName = "name1")]
		public string Name1 { get; set; }
		[XmlElement(ElementName = "email")]
		public string Email { get; set; }
		[XmlElement(ElementName = "nightPhone")]
		public string NightPhone { get; set; }
		[XmlAttribute(AttributeName = "personPlaceID")]
		public string PersonPlaceID { get; set; }
		[XmlElement(ElementName = "dayPhone")]
		public string DayPhone { get; set; }
		[XmlElement(ElementName = "address1")]
		public string Address1 { get; set; }
		[XmlElement(ElementName = "city")]
		public string City { get; set; }
		[XmlElement(ElementName = "state")]
		public string State { get; set; }
		[XmlElement(ElementName = "country")]
		public string Country { get; set; }
		[XmlElement(ElementName = "postalCode")]
		public string PostalCode { get; set; }
		[XmlElement(ElementName = "partnerPersonPlaceId")]
		public string PartnerPersonPlaceId { get; set; }
		[XmlElement(ElementName = "addressRateClass")]
		public string AddressRateClass { get; set; }
	}

	[XmlRoot(ElementName = "hubOrder")]
	public class HubOrder
	{
		[XmlElement(ElementName = "participatingParty")]
		public ParticipatingParty ParticipatingParty { get; set; }
		[XmlElement(ElementName = "sendersIdForReceiver")]
		public string SendersIdForReceiver { get; set; }
		[XmlElement(ElementName = "orderId")]
		public string OrderId { get; set; }
		[XmlElement(ElementName = "lineCount")]
		public string LineCount { get; set; }
		[XmlElement(ElementName = "poNumber")]
		public string PoNumber { get; set; }
		[XmlElement(ElementName = "orderDate")]
		public string OrderDate { get; set; }
		[XmlElement(ElementName = "shipTo")]
		public ShipTo ShipTo { get; set; }
		[XmlElement(ElementName = "billTo")]
		public BillTo BillTo { get; set; }
		[XmlElement(ElementName = "customer")]
		public Customer Customer { get; set; }
		[XmlElement(ElementName = "invoiceTo")]
		public InvoiceTo InvoiceTo { get; set; }
		[XmlElement(ElementName = "shippingCode")]
		public string ShippingCode { get; set; }
		[XmlElement(ElementName = "custOrderNumber")]
		public string CustOrderNumber { get; set; }
		[XmlElement(ElementName = "poHdrData")]
		public PoHdrData PoHdrData { get; set; }
		[XmlElement(ElementName = "lineItem")]
		public List<LineItem> LineItem { get; set; }
		[XmlElement(ElementName = "personPlace")]
		public List<PersonPlace> PersonPlace { get; set; }
		[XmlAttribute(AttributeName = "transactionID")]
		public string TransactionID { get; set; }
	}

	[XmlRoot(ElementName = "OrderMessageBatch")]
	public class OrderMessageBatch
	{
		[XmlElement(ElementName = "partnerID")]
		public PartnerID PartnerID { get; set; }
		[XmlElement(ElementName = "hubOrder")]
		public List<HubOrder> HubOrder { get; set; }
		[XmlElement(ElementName = "messageCount")]
		public string MessageCount { get; set; }
		[XmlAttribute(AttributeName = "batchNumber")]
		public string BatchNumber { get; set; }
	}

