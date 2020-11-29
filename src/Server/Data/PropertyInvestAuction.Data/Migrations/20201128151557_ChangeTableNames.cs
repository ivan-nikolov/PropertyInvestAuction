using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyInvestAuction.Data.Migrations
{
    public partial class ChangeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Neighborhood_NeighborhoodId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Bid_AspNetUsers_UserId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_Bid_Offer_OfferId",
                table: "Bid");

            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_ReceiverId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighborhood_City_CityId",
                table: "Neighborhood");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_AspNetUsers_UserId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Offer_Property_PropertyId",
                table: "Offer");

            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Property_PropertyId",
                table: "Photo");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Address_AddressId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_AspNetUsers_UserId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Property_Category_CategoryId",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Property",
                table: "Property");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photo",
                table: "Photo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offer",
                table: "Offer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Neighborhood",
                table: "Neighborhood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Message",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bid",
                table: "Bid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Property",
                newName: "Properties");

            migrationBuilder.RenameTable(
                name: "Photo",
                newName: "Photos");

            migrationBuilder.RenameTable(
                name: "Offer",
                newName: "Offers");

            migrationBuilder.RenameTable(
                name: "Neighborhood",
                newName: "Neighborhoods");

            migrationBuilder.RenameTable(
                name: "Message",
                newName: "Messages");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "Bid",
                newName: "Bids");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Property_UserId",
                table: "Properties",
                newName: "IX_Properties_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_IsDeleted",
                table: "Properties",
                newName: "IX_Properties_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Property_CategoryId",
                table: "Properties",
                newName: "IX_Properties_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_AddressId",
                table: "Properties",
                newName: "IX_Properties_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_PropertyId",
                table: "Photos",
                newName: "IX_Photos_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_UserId",
                table: "Offers",
                newName: "IX_Offers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_PropertyId",
                table: "Offers",
                newName: "IX_Offers_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Offer_IsDeleted",
                table: "Offers",
                newName: "IX_Offers_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Neighborhood_IsDeleted",
                table: "Neighborhoods",
                newName: "IX_Neighborhoods_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Neighborhood_CityId",
                table: "Neighborhoods",
                newName: "IX_Neighborhoods_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_SenderId",
                table: "Messages",
                newName: "IX_Messages_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_ReceiverId",
                table: "Messages",
                newName: "IX_Messages_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Message_IsDeleted",
                table: "Messages",
                newName: "IX_Messages_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Country_IsDeleted",
                table: "Countries",
                newName: "IX_Countries_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_City_IsDeleted",
                table: "Cities",
                newName: "IX_Cities_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryId",
                table: "Cities",
                newName: "IX_Cities_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_IsDeleted",
                table: "Categories",
                newName: "IX_Categories_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_UserId",
                table: "Bids",
                newName: "IX_Bids_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_OfferId",
                table: "Bids",
                newName: "IX_Bids_OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Bid_IsDeleted",
                table: "Bids",
                newName: "IX_Bids_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Address_NeighborhoodId",
                table: "Addresses",
                newName: "IX_Addresses_NeighborhoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_IsDeleted",
                table: "Addresses",
                newName: "IX_Addresses_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CityId",
                table: "Addresses",
                newName: "IX_Addresses_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Properties",
                table: "Properties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offers",
                table: "Offers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Neighborhoods",
                table: "Neighborhoods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Messages",
                table: "Messages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bids",
                table: "Bids",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Neighborhoods_NeighborhoodId",
                table: "Addresses",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AspNetUsers_UserId",
                table: "Bids",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Offers_OfferId",
                table: "Bids",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighborhoods_Cities_CityId",
                table: "Neighborhoods",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_UserId",
                table: "Offers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Properties_PropertyId",
                table: "Offers",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Properties_PropertyId",
                table: "Photos",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_UserId",
                table: "Properties",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Cities_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Neighborhoods_NeighborhoodId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AspNetUsers_UserId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Offers_OfferId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_ReceiverId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SenderId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighborhoods_Cities_CityId",
                table: "Neighborhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_UserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Properties_PropertyId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Properties_PropertyId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_UserId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Categories_CategoryId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Properties",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Offers",
                table: "Offers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Neighborhoods",
                table: "Neighborhoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Messages",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bids",
                table: "Bids");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Properties",
                newName: "Property");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Photo");

            migrationBuilder.RenameTable(
                name: "Offers",
                newName: "Offer");

            migrationBuilder.RenameTable(
                name: "Neighborhoods",
                newName: "Neighborhood");

            migrationBuilder.RenameTable(
                name: "Messages",
                newName: "Message");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "Bids",
                newName: "Bid");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_UserId",
                table: "Property",
                newName: "IX_Property_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_IsDeleted",
                table: "Property",
                newName: "IX_Property_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_CategoryId",
                table: "Property",
                newName: "IX_Property_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_AddressId",
                table: "Property",
                newName: "IX_Property_AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_PropertyId",
                table: "Photo",
                newName: "IX_Photo_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_UserId",
                table: "Offer",
                newName: "IX_Offer_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_PropertyId",
                table: "Offer",
                newName: "IX_Offer_PropertyId");

            migrationBuilder.RenameIndex(
                name: "IX_Offers_IsDeleted",
                table: "Offer",
                newName: "IX_Offer_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Neighborhoods_IsDeleted",
                table: "Neighborhood",
                newName: "IX_Neighborhood_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Neighborhoods_CityId",
                table: "Neighborhood",
                newName: "IX_Neighborhood_CityId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_SenderId",
                table: "Message",
                newName: "IX_Message_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_ReceiverId",
                table: "Message",
                newName: "IX_Message_ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Messages_IsDeleted",
                table: "Message",
                newName: "IX_Message_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_IsDeleted",
                table: "Country",
                newName: "IX_Country_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_IsDeleted",
                table: "City",
                newName: "IX_City_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryId",
                table: "City",
                newName: "IX_City_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_IsDeleted",
                table: "Category",
                newName: "IX_Category_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_UserId",
                table: "Bid",
                newName: "IX_Bid_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_OfferId",
                table: "Bid",
                newName: "IX_Bid_OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_IsDeleted",
                table: "Bid",
                newName: "IX_Bid_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_NeighborhoodId",
                table: "Address",
                newName: "IX_Address_NeighborhoodId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_IsDeleted",
                table: "Address",
                newName: "IX_Address_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityId",
                table: "Address",
                newName: "IX_Address_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Property",
                table: "Property",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photo",
                table: "Photo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Offer",
                table: "Offer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Neighborhood",
                table: "Neighborhood",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Message",
                table: "Message",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bid",
                table: "Bid",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_CityId",
                table: "Address",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Neighborhood_NeighborhoodId",
                table: "Address",
                column: "NeighborhoodId",
                principalTable: "Neighborhood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_AspNetUsers_UserId",
                table: "Bid",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bid_Offer_OfferId",
                table: "Bid",
                column: "OfferId",
                principalTable: "Offer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                table: "City",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_ReceiverId",
                table: "Message",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_AspNetUsers_SenderId",
                table: "Message",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighborhood_City_CityId",
                table: "Neighborhood",
                column: "CityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_AspNetUsers_UserId",
                table: "Offer",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_Property_PropertyId",
                table: "Offer",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Property_PropertyId",
                table: "Photo",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Address_AddressId",
                table: "Property",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_AspNetUsers_UserId",
                table: "Property",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Property_Category_CategoryId",
                table: "Property",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
