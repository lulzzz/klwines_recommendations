using System;
using System.Collections.Generic;

namespace Domain
{
    public class SKU
    {
        public int score;
        public Highlights highlights;
        public Record Record;
    }

    public class Highlights { }

    public class Record
    {
        public string Sku;
        public int Vintage;
        public string ItemName;
        public int ListPrice;
        public int ImageAvailableYN;
        public int Allocation;
        public int GiftBoxYN;
        public string ImageLargeURL;
        public string ImageExtraLargeURL;
        public string ImageSmallURL;
        public string ImageMediumURL;
        public string ProductType;
        public string ProductGroup;
        public string ImageUrl;
        public int WineClubYN;
        public int ClubPrice;
        public int BackInStockYN;
        public int TopPickYN;
        public int QtyOnHand;
        public int QtyOnOrder;
        public int InventoryValue;
        public int QtySoldLast30;
        public int QtySoldLast30Value;
        public int QtySoldLifetime;
        public int QtySoldLifetimeValue;
        public int LowerLimit;
        public int WebSkipYN;
        public int IsAuction;
        public int ActiveYN;
        public int SpecialOrderYN;
        public int SpecialOrderETA7YN;
        public DateTime specialOrderETADate;
        public int OutOfStockYN;
        public int MlgtLimit;
        public int PreArrivalYN;
        public int InsiderHiddenPricingYN;
        public int AvailableHollywoodYN;
        public int AvailableSanCarlosYN;
        public int AvailableRedwoodCityYN;
        public int AvailableSanFranciscoYN;
        public int QtyOnHandSanCarlos;
        public int QtyOnHandRedwoodCity;
        public int QtyOnHandSanFrancisco;
        public int QtyOnHandHollywood;
        public string TastingNotes;
        public string FormattedTastingNotes;
        public string LotItemNames;
        public int LotItemCount;
        public int WinningBidAmount;
        public int NumberBids;
        public string LotVintagePrefix;
        public int IsOWCYN;
        public int IsPreviouslyYN;
        public string PreviouslyValue;
        public int IsElsewhereYN;
        public string ElsewhereValue;
        public DateTime AuctionStartDT;
        public DateTime AuctionEndDT;
        public string Country;
        public string SubRegion;
        public string SpecificAppellation;
        public string Varietal;
        public int AlcoholContent;
        public int OrganicYN;
        public int CaseQuantity;
        public int CasePriceVisibleYN;
        public int HalfCasePriceVisibleYN;
        public int PrivateYN;
        public int NewYN;
        public int ComingSoonYN;
        public int NewProductFeedYN;
        public DateTime NewProductFeedDate;
        public int NumberOfStaffReview;
        public int NumberOfReviewScoreReviews;
        public int LotGeneratedFromPOYN;
        public List<Inventory> Availability;
        public string[] HighlightedDesignations;
        public int[] Scores;
    }

    public class Inventory
    {
        public string LocationName;
        public string LocationAbbreviation;
        public int QuantityAvaliable;
    }
}
