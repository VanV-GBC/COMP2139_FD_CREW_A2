using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GBCSporting2021_FD_Crew.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "AFG", "004", "Afghanistan" },
                    { "NIC", "558", "Nicaragua" },
                    { "NER", "562", "Niger" },
                    { "NGA", "566", "Nigeria" },
                    { "NIU", "570", "Niue" },
                    { "NFK", "574", "Norfolk Island" },
                    { "MKD", "807", "North Macedonia" },
                    { "MNP", "580", "Northern Mariana Islands" },
                    { "NOR", "578", "Norway" },
                    { "OMN", "512", "Oman" },
                    { "PAK", "586", "Pakistan" },
                    { "PLW", "585", "Palau" },
                    { "PSE", "275", "Palestine, State of" },
                    { "PAN", "591", "Panama" },
                    { "PNG", "598", "Papua New Guinea" },
                    { "PRY", "600", "Paraguay" },
                    { "PER", "604", "Peru" },
                    { "PHL", "608", "Philippines" },
                    { "PCN", "612", "Pitcairn" },
                    { "POL", "616", "Poland" },
                    { "PRT", "620", "Portugal" },
                    { "PRI", "630", "Puerto Rico" },
                    { "QAT", "634", "Qatar" },
                    { "REU", "638", "Réunion" },
                    { "ROU", "642", "Romania" },
                    { "RUS", "643", "Russian Federation" },
                    { "RWA", "646", "Rwanda" },
                    { "BLM", "652", "Saint Barthélemy" },
                    { "NZL", "554", "New Zealand" },
                    { "SHN", "654", "Saint Helena, Ascension and Tristan da Cunha" },
                    { "NCL", "540", "New Caledonia" },
                    { "NPL", "524", "Nepal" },
                    { "LBY", "434", "Libya" },
                    { "LIE", "438", "Liechtenstein" },
                    { "LTU", "440", "Lithuania" },
                    { "LUX", "442", "Luxembourg" },
                    { "MAC", "446", "Macao" },
                    { "MDG", "450", "Madagascar" },
                    { "MWI", "454", "Malawi" },
                    { "MYS", "458", "Malaysia" },
                    { "MDV", "462", "Maldives" },
                    { "MLI", "466", "Mali" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "MLT", "470", "Malta" },
                    { "MHL", "584", "Marshall Islands" },
                    { "MTQ", "474", "Martinique" },
                    { "MRT", "478", "Mauritania" },
                    { "MYT", "175", "Mayotte" },
                    { "MEX", "484", "Mexico" },
                    { "FSM", "583", "Micronesia (Federated States of)" },
                    { "MDA", "498", "Moldova, Republic of" },
                    { "MCO", "492", "Monaco" },
                    { "MNG", "496", "Mongolia" },
                    { "MNE", "499", "Montenegro" },
                    { "MSR", "500", "Montserrat" },
                    { "MAR", "504", "Morocco" },
                    { "MOZ", "508", "Mozambique" },
                    { "MMR", "104", "Myanmar" },
                    { "NAM", "516", "Namibia" },
                    { "NRU", "520", "Nauru" },
                    { "NLD", "528", "Netherlands" },
                    { "KNA", "659", "Saint Kitts and Nevis" },
                    { "LCA", "662", "Saint Lucia" },
                    { "MAF", "663", "Saint Martin (French part)" },
                    { "TGO", "768", "Togo" },
                    { "TKL", "772", "Tokelau" },
                    { "TON", "776", "Tonga" },
                    { "TTO", "780", "Trinidad and Tobago" },
                    { "TUN", "788", "Tunisia" },
                    { "TUR", "792", "Turkey" },
                    { "TKM", "795", "Turkmenistan" },
                    { "TCA", "796", "Turks and Caicos Islands" },
                    { "TUV", "798", "Tuvalu" },
                    { "UGA", "800", "Uganda" },
                    { "UKR", "804", "Ukraine" },
                    { "ARE", "784", "United Arab Emirates" },
                    { "GBR", "826", "United Kingdom of Great Britain and Northern Ireland" },
                    { "USA", "840", "United States of America" },
                    { "UMI", "581", "United States Minor Outlying Islands" },
                    { "URY", "858", "Uruguay" },
                    { "UZB", "860", "Uzbekistan" },
                    { "VUT", "548", "Vanuatu" },
                    { "VEN", "862", "Venezuela (Bolivarian Republic of)" },
                    { "VNM", "704", "Viet Nam" },
                    { "VGB", "092", "Virgin Islands (British)" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "VIR", "850", "Virgin Islands (U.S.)" },
                    { "WLF", "876", "Wallis and Futuna" },
                    { "ESH", "732", "Western Sahara" },
                    { "YEM", "887", "Yemen" },
                    { "ZMB", "894", "Zambia" },
                    { "ZWE", "716", "Zimbabwe" },
                    { "TLS", "626", "Timor-Leste" },
                    { "THA", "764", "Thailand" },
                    { "TZA", "834", "Tanzania, United Republic of" },
                    { "TJK", "762", "Tajikistan" },
                    { "SPM", "666", "Saint Pierre and Miquelon" },
                    { "VCT", "670", "Saint Vincent and the Grenadines" },
                    { "WSM", "882", "Samoa" },
                    { "SMR", "674", "San Marino" },
                    { "STP", "678", "Sao Tome and Principe" },
                    { "SAU", "682", "Saudi Arabia" },
                    { "SEN", "686", "Senegal" },
                    { "SRB", "688", "Serbia" },
                    { "SYC", "690", "Seychelles" },
                    { "SLE", "694", "Sierra Leone" },
                    { "SGP", "702", "Singapore" },
                    { "SXM", "534", "Sint Maarten (Dutch part)" },
                    { "SVK", "703", "Slovakia" },
                    { "LBR", "430", "Liberia" },
                    { "SVN", "705", "Slovenia" },
                    { "SOM", "706", "Somalia" },
                    { "ZAF", "710", "South Africa" },
                    { "SGS", "239", "South Georgia and the South Sandwich Islands" },
                    { "SSD", "728", "South Sudan" },
                    { "ESP", "724", "Spain" },
                    { "LKA", "144", "Sri Lanka" },
                    { "SDN", "729", "Sudan" },
                    { "SUR", "740", "SuricountryName" },
                    { "SJM", "744", "Svalbard and Jan Mayen" },
                    { "SWE", "752", "Sweden" },
                    { "CHE", "756", "Switzerland" },
                    { "SYR", "760", "Syrian Arab Republic" },
                    { "TWN", "158", "Taiwan, Province of China" },
                    { "SLB", "090", "Solomon Islands" },
                    { "LSO", "426", "Lesotho" },
                    { "MUS", "480", "Mauritius" },
                    { "LVA", "428", "Latvia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "BRN", "096", "Brunei Darussalam" },
                    { "BGR", "100", "Bulgaria" },
                    { "BFA", "854", "Burkina Faso" },
                    { "BDI", "108", "Burundi" },
                    { "CPV", "132", "Cabo Verde" },
                    { "KHM", "116", "Cambodia" },
                    { "CMR", "120", "Cameroon" },
                    { "CAN", "124", "Canada" },
                    { "CYM", "136", "Cayman Islands" },
                    { "CAF", "140", "Central African Republic" },
                    { "TCD", "148", "Chad" },
                    { "CHL", "152", "Chile" },
                    { "LBN", "422", "Lebanon" },
                    { "CXR", "162", "Christmas Island" },
                    { "CCK", "166", "Cocos (Keeling) Islands" },
                    { "COL", "170", "Colombia" },
                    { "COM", "174", "Comoros" },
                    { "COG", "178", "Congo" },
                    { "COD", "180", "Congo, Democratic Republic of the" },
                    { "COK", "184", "Cook Islands" },
                    { "CRI", "188", "Costa Rica" },
                    { "CIV", "384", "Côte d'Ivoire" },
                    { "HRV", "191", "Croatia" },
                    { "CUB", "192", "Cuba" },
                    { "CUW", "531", "Curaçao" },
                    { "CYP", "196", "Cyprus" },
                    { "CZE", "203", "Czechia" },
                    { "IOT", "086", "British Indian Ocean Territory" },
                    { "BRA", "076", "Brazil" },
                    { "BVT", "074", "Bouvet Island" },
                    { "BWA", "072", "Botswana" },
                    { "ALA", "248", "Åland Islands" },
                    { "ALB", "008", "Albania" },
                    { "DZA", "012", "Algeria" },
                    { "ASM", "016", "American Samoa" },
                    { "AND", "020", "Andorra" },
                    { "AGO", "024", "Angola" },
                    { "AIA", "660", "Anguilla" },
                    { "ATA", "010", "Antarctica" },
                    { "ATG", "028", "Antigua and Barbuda" },
                    { "ARG", "032", "Argentina" },
                    { "ARM", "051", "Armenia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "ABW", "533", "Aruba" },
                    { "AUS", "036", "Australia" },
                    { "DNK", "208", "Denmark" },
                    { "AUT", "040", "Austria" },
                    { "BHS", "044", "Bahamas" },
                    { "BHR", "048", "Bahrain" },
                    { "BGD", "050", "Bangladesh" },
                    { "BRB", "052", "Barbados" },
                    { "BLR", "112", "Belarus" },
                    { "BEL", "056", "Belgium" },
                    { "BLZ", "084", "Belize" },
                    { "BEN", "204", "Benin" },
                    { "BMU", "060", "Bermuda" },
                    { "BTN", "064", "Bhutan" },
                    { "BOL", "068", "Bolivia (Plurinational State of)" },
                    { "BES", "535", "Bonaire, Sint Eustatius and Saba" },
                    { "BIH", "070", "Bosnia and Herzegovina" },
                    { "AZE", "031", "Azerbaijan" },
                    { "DJI", "262", "Djibouti" },
                    { "CHN", "156", "China" },
                    { "DOM", "214", "Dominican Republic" },
                    { "HTI", "332", "Haiti" },
                    { "HMD", "334", "Heard Island and McDonald Islands" },
                    { "VAT", "336", "Holy See" },
                    { "HND", "340", "Honduras" },
                    { "HKG", "344", "Hong Kong" },
                    { "HUN", "348", "Hungary" },
                    { "ISL", "352", "Iceland" },
                    { "IND", "356", "India" },
                    { "IDN", "360", "Indonesia" },
                    { "IRN", "364", "Iran (Islamic Republic of)" },
                    { "IRQ", "368", "Iraq" },
                    { "IRL", "372", "Ireland" },
                    { "IMN", "833", "Isle of Man" },
                    { "DMA", "212", "Dominica" },
                    { "ITA", "380", "Italy" },
                    { "JAM", "388", "Jamaica" },
                    { "JPN", "392", "Japan" },
                    { "JEY", "832", "Jersey" },
                    { "JOR", "400", "Jordan" },
                    { "KAZ", "398", "Kazakhstan" },
                    { "KEN", "404", "Kenya" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "KIR", "296", "Kiribati" },
                    { "PRK", "408", "Korea (Democratic People's Republic of)" },
                    { "KOR", "410", "Korea, Republic of" },
                    { "KWT", "414", "Kuwait" },
                    { "KGZ", "417", "Kyrgyzstan" },
                    { "LAO", "418", "Lao People's Democratic Republic" },
                    { "GUY", "328", "Guyana" },
                    { "GNB", "624", "Guinea-Bissau" },
                    { "ISR", "376", "Israel" },
                    { "GGY", "831", "Guernsey" },
                    { "ECU", "218", "Ecuador" },
                    { "EGY", "818", "Egypt" },
                    { "SLV", "222", "El Salvador" },
                    { "GNQ", "226", "Equatorial Guinea" },
                    { "ERI", "232", "Eritrea" },
                    { "EST", "233", "Estonia" },
                    { "SWZ", "748", "Eswatini" },
                    { "ETH", "231", "Ethiopia" },
                    { "FLK", "238", "Falkland Islands (Malvinas)" },
                    { "FRO", "234", "Faroe Islands" },
                    { "FJI", "242", "Fiji" },
                    { "FIN", "246", "Finland" },
                    { "FRA", "250", "France" },
                    { "GUF", "254", "French Guiana" },
                    { "PYF", "258", "French Polynesia" },
                    { "ATF", "260", "French Southern Territories" },
                    { "GAB", "266", "Gabon" },
                    { "GMB", "270", "Gambia" },
                    { "GEO", "268", "Georgia" },
                    { "DEU", "276", "Germany" },
                    { "GHA", "288", "Ghana" },
                    { "GIB", "292", "Gibraltar" },
                    { "GRC", "300", "Greece" },
                    { "GRL", "304", "Greenland" },
                    { "GRD", "308", "Grenada" },
                    { "GLP", "312", "Guadeloupe" },
                    { "GUM", "316", "Guam" },
                    { "GTM", "320", "Guatemala" },
                    { "GIN", "324", "Guinea" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductCode", "ProductName", "ReleaseDate" },
                values: new object[,]
                {
                    { 5, 8.38m, "COUCH20", "Couch Potato Faceoff PPV Event", new DateTime(2021, 1, 30, 17, 57, 14, 0, DateTimeKind.Unspecified) },
                    { 4, 3.87m, "ZUCKHUNT", "Hunting Finals - Zuckerberg edition", new DateTime(2020, 4, 29, 18, 6, 30, 0, DateTimeKind.Unspecified) },
                    { 3, 7.07m, "ROCK02", "Rock Throwing Championship 2.0", new DateTime(2020, 8, 8, 19, 58, 8, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductCode", "ProductName", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 7.54m, "HOCK21", "Hockey PPV 2021", new DateTime(2020, 6, 14, 6, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 2, 9.68m, "SOCK01", "Soccer Hooligan Fights 1.0", new DateTime(2020, 10, 20, 2, 58, 26, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 28, "ttrobeyr@rediff.com", "Tillie Trobey", "(414) 6765629" },
                    { 27, "clamboleq@latimes.com", "Clarence Lambole", "(488) 5840432" },
                    { 26, "msimoncellip@vimeo.com", "Magnum Simoncelli", "(173) 9479908" },
                    { 25, "hpagano@alibaba.com", "Henri Pagan", "(673) 5337764" },
                    { 24, "rgregoren@alexa.com", "Reg Gregore", "(497) 9522755" },
                    { 23, "lcarrodusm@cloudflare.com", "Lexy Carrodus", "(546) 5259083" },
                    { 22, "kharwinl@seesaa.net", "Karel Harwin", "(139) 1248750" },
                    { 21, "akincaidk@mozilla.com", "Augustine Kincaid", "(637) 9140087" },
                    { 20, "kkernockej@netvibes.com", "Kelcy Kernocke", "(495) 1613647" },
                    { 19, "dbucheri@pbs.org", "Di Bucher", "(658) 6414862" },
                    { 18, "syeabsleyh@mapquest.com", "Salome Yeabsley", "(196) 4370797" },
                    { 17, "dbeverageg@aboutads.info", "Doll Beverage", "(186) 8941499" },
                    { 16, "vwoodyearf@ted.com", "Van Woodyear", "(878) 8746082" },
                    { 15, "mpeffere@thetimes.co.uk", "Margery Peffer", "(786) 3655469" },
                    { 14, "lmaryond@topsy.com", "Linn Maryon", "(282) 7960687" },
                    { 12, "tzanninib@php.net", "Travus Zannini", "(881) 1956460" },
                    { 11, "jcopyna@marriott.com", "Joni Copyn", "(658) 2184530" },
                    { 10, "bbedson9@skyrock.com", "Bobina Bedson", "(582) 6930219" },
                    { 9, "tdearnly8@amazon.co.uk", "Tybi Dearnly", "(945) 9132417" },
                    { 8, "hbaumford7@alibaba.com", "Hugh Baumford", "(313) 6544268" },
                    { 7, "amixture6@mapquest.com", "Alisander Mixture", "(539) 9826601" },
                    { 6, "ccracknall5@t-online.de", "Cullen Cracknall", "(396) 2561309" },
                    { 5, "cmathy4@google.co.uk", "Clari Mathy", "(928) 1519176" },
                    { 4, "klynthal3@bloomberg.com", "Kylen Lynthal", "(385) 9669354" },
                    { 3, "splaskett2@diigo.com", "Saunderson Plaskett", "(641) 8705955" },
                    { 2, "smichieli1@ucla.edu", "Stoddard Michieli", "(352) 3948039" },
                    { 1, "nformoy0@shinystat.com", "Neil Formoy", "(166) 8471988" },
                    { 29, "svasilkovs@bigcartel.com", "Stanwood Vasilkov", "(745) 5655554" },
                    { 13, "rcorradic@tuttocitta.it", "Rois Corradi", "(854) 8298792" },
                    { 30, "grobertsent@rambler.ru", "Gelya Robertsen", "(931) 7061643" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 1, "94175 Spaight Pass", "Linköping", "CAN", "bferronier0@ft.com", "Briant", "Ferronier", "441-524-5742", "589 41", "Östergötland" },
                    { 2, "6 Carioca Street", "Hrušovany u Brna", "CAN", "pparslow1@usa.gov", "Pauly", "Parslow", "283-811-1291", "664 62", "Ontario" },
                    { 3, "13476 Northwestern Lane", "Mirriah", "CAN", "bcordle2@google.com.br", "Beret", "Cordle", "230-306-7553", "664 62", "Ontario" },
                    { 4, "9 Southridge Street", "Vahdat", "USA", "bmcness3@techcrunch.com", "Bernard", "McNess", "339-957-2666", "664 62", "Ontario" },
                    { 5, "14 Arkansas Center", "Kurortnyy", "USA", "rewington4@ucsd.edu", "Roberta", "Ewington", "588-541-4858", "197738", "Ohio" },
                    { 6, "0 Algoma Point", "Yong’an", "USA", "rblaxley5@skyrock.com", "Ricoriki", "Blaxley", "340-227-0604", "664 62", "Ontario" },
                    { 7, "5657 Mariners Cove Terrace", "Zamarski", "USA", "gshay6@epa.gov", "Garey", "Shay", "953-845-7062", "43-419", "Arizona" },
                    { 8, "4187 Mitchell Center", "Martapura", "USA", "syurocjkin7@hud.gov", "Stanislaus", "Yurocjkin", "250-839-9907", "66699", "Mars" },
                    { 9, "09265 Lukken Way", "Wręczyca Wielka", "USA", "bspicer8@google.it", "Bendicty", "Spicer", "740-985-6558", "42-284", "Pluto" },
                    { 10, "24223 Birchwood Junction", "Casais", "USA", "fboydell9@ustream.tv", "Faydra", "Boydell", "739-139-5608", "3100-806", "Leiria" },
                    { 11, "58 Dwight Avenue", "Cayna", "USA", "amordea@ca.gov", "Archaimbaud", "Morde", "121-134-1498", "234234", "Ontario" },
                    { 12, "9565 Hoepker Point", "Nagorsk", "USA", "spitbladob@yelp.com", "Susanne", "Pitblado", "491-587-2265", "613261", "New York" },
                    { 13, "2 Donald Center", "Ārt Khwājah", "USA", "ldoulc@sciencedaily.com", "Lyon", "Doul", "904-538-4032", "22233", "Alberta" },
                    { 14, "70574 Warrior Parkway", "Bealanana", "USA", "kbraithwaited@dailymotion.com", "Kaitlynn", "Braithwaite", "712-460-6508", "22345", "Newfoundland" },
                    { 15, "870 Milwaukee Street", "Puncaksari", "USA", "sgeroe@google.ru", "Suzy", "Gero", "163-910-1575", "543643", "Florida" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "Description", "ProductId", "TechnicianId", "Title", "dateClosed", "dateOpened" },
                values: new object[] { 2, 1, "This is a seeded description placeholder", 5, 4, "Tester's Delight Error", new DateTime(2020, 6, 14, 12, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "Description", "ProductId", "TechnicianId", "Title", "dateClosed", "dateOpened" },
                values: new object[] { 1, 2, "This is a seeded description placeholder", 3, 4, "I'm tryin' Captain, can't reach the button", new DateTime(2020, 6, 14, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "Description", "ProductId", "TechnicianId", "Title", "dateClosed", "dateOpened" },
                values: new object[] { 3, 9, "This is a seeded description placeholder", 4, 6, "To be or not to be", new DateTime(2020, 6, 14, 17, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 3, 21, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CustomerId",
                table: "Registrations",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
