using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class MigratonName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    animals_id = table.Column<int>(type: "int", nullable: false),
                    animal_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    animal_birth_date = table.Column<DateTime>(type: "date", nullable: true),
                    animal_type = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Animals__9DF80BFF8735FEBC", x => x.animals_id);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    plant_name = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false),
                    plant_type = table.Column<string>(type: "char(255)", unicode: false, fixedLength: true, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.plant_id);
                });

            migrationBuilder.CreateTable(
                name: "Poll",
                columns: table => new
                {
                    poll_id = table.Column<int>(type: "int", nullable: false),
                    poll_question = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    poll_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poll", x => x.poll_id);
                });

            migrationBuilder.CreateTable(
                name: "Shop",
                columns: table => new
                {
                    shop_id = table.Column<int>(type: "int", nullable: false),
                    shop_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    city = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    street = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    house_number = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shop", x => x.shop_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "char(52)", unicode: false, fixedLength: true, maxLength: 52, nullable: false),
                    last_name = table.Column<string>(type: "char(52)", unicode: false, fixedLength: true, maxLength: 52, nullable: false),
                    middle_name = table.Column<string>(type: "char(52)", unicode: false, fixedLength: true, maxLength: 52, nullable: true),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    username = table.Column<string>(type: "char(128)", unicode: false, fixedLength: true, maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "char(128)", unicode: false, fixedLength: true, maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Feeding_schedule",
                columns: table => new
                {
                    feeding_id = table.Column<int>(type: "int", nullable: false),
                    animals_id = table.Column<int>(type: "int", nullable: false),
                    feeding_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    feeding_type = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    feeding_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Feeding___847B1963D96CEC8A", x => new { x.feeding_id, x.animals_id });
                    table.ForeignKey(
                        name: "FK__Feeding_s__anima__5FB337D6",
                        column: x => x.animals_id,
                        principalTable: "Animals",
                        principalColumn: "animals_id");
                });

            migrationBuilder.CreateTable(
                name: "Fertilization",
                columns: table => new
                {
                    fertilization_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    fertilization_date = table.Column<DateTime>(type: "date", nullable: false),
                    fertilizer_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Fertiliz__BD767B33E6118EA9", x => new { x.fertilization_id, x.plant_id });
                    table.ForeignKey(
                        name: "FK__Fertiliza__plant__31EC6D26",
                        column: x => x.plant_id,
                        principalTable: "Plant",
                        principalColumn: "plant_id");
                });

            migrationBuilder.CreateTable(
                name: "Harvest",
                columns: table => new
                {
                    harvest_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    harvest_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Harvest__84D00DF6B396193D", x => new { x.harvest_id, x.plant_id });
                    table.ForeignKey(
                        name: "FK__Harvest__plant_i__34C8D9D1",
                        column: x => x.plant_id,
                        principalTable: "Plant",
                        principalColumn: "plant_id");
                });

            migrationBuilder.CreateTable(
                name: "Planting",
                columns: table => new
                {
                    planting_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    planting_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Planting__2FE4309A8E1E368F", x => new { x.planting_id, x.plant_id });
                    table.ForeignKey(
                        name: "FK__Planting__plant___2C3393D0",
                        column: x => x.plant_id,
                        principalTable: "Plant",
                        principalColumn: "plant_id");
                });

            migrationBuilder.CreateTable(
                name: "WateringSchedule",
                columns: table => new
                {
                    watering_schedule_id = table.Column<int>(type: "int", nullable: false),
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    watering_date = table.Column<DateTime>(type: "date", nullable: false),
                    watering_time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Watering__8FE115C83BABBAD8", x => new { x.watering_schedule_id, x.plant_id });
                    table.ForeignKey(
                        name: "FK__WateringS__plant__2F10007B",
                        column: x => x.plant_id,
                        principalTable: "Plant",
                        principalColumn: "plant_id");
                });

            migrationBuilder.CreateTable(
                name: "PollOption",
                columns: table => new
                {
                    option_id = table.Column<int>(type: "int", nullable: false),
                    poll_id = table.Column<int>(type: "int", nullable: false),
                    option_text = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PollOpti__8BB6231648088261", x => new { x.option_id, x.poll_id });
                    table.ForeignKey(
                        name: "FK__PollOptio__poll___398D8EEE",
                        column: x => x.poll_id,
                        principalTable: "Poll",
                        principalColumn: "poll_id");
                });

            migrationBuilder.CreateTable(
                name: "Product_in_shop",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false),
                    shop_id = table.Column<int>(type: "int", nullable: false),
                    product_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    product_price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product___3DD2FC8DBB0179AE", x => new { x.product_id, x.shop_id });
                    table.ForeignKey(
                        name: "FK__Product_i__shop___5070F446",
                        column: x => x.shop_id,
                        principalTable: "Shop",
                        principalColumn: "shop_id");
                });

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    announcements_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    announcement_topic = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    announcement_description = table.Column<string>(type: "text", nullable: false),
                    announcement_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Announce__160413B9DCAF2039", x => new { x.announcements_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__Announcem__user___534D60F1",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    message_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    message_text = table.Column<string>(type: "text", nullable: false),
                    message_time = table.Column<TimeSpan>(type: "time", nullable: false),
                    message_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Message__E0248D96283DA771", x => new { x.message_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__Message__user_id__4316F928",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    news_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    news_title = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    news_text = table.Column<string>(type: "text", nullable: false),
                    news_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__A7BC2FA8EB3AEB9F", x => new { x.news_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__News__user_id__403A8C7D",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    payments_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    payment_type = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    payment_amount = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "date", nullable: false),
                    penalty_amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__2C80D27F130C2D2B", x => new { x.payments_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__Payments__user_i__45F365D3",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "SNT",
                columns: table => new
                {
                    snt_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    snt_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    city = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    street = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    house_number = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    manager_first_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    manager_last_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    manager_phone = table.Column<string>(type: "char(12)", unicode: false, fixedLength: true, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SNT__BF75E806B81E5FF5", x => new { x.snt_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__SNT__user_id__48CFD27E",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserAnimals",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    animals_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserAnim__5061B7B0CC4C6DB2", x => new { x.user_id, x.animals_id });
                    table.ForeignKey(
                        name: "FK__UserAnima__anima__5CD6CB2B",
                        column: x => x.animals_id,
                        principalTable: "Animals",
                        principalColumn: "animals_id");
                    table.ForeignKey(
                        name: "FK__UserAnima__user___5BE2A6F2",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserPlants",
                columns: table => new
                {
                    plant_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserPlan__4EED50C4A1F71E2F", x => new { x.plant_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__UserPlant__plant__286302EC",
                        column: x => x.plant_id,
                        principalTable: "Plant",
                        principalColumn: "plant_id");
                    table.ForeignKey(
                        name: "FK__UserPlant__user___29572725",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "UserShops",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    shop_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserShop__C36EB6770AEB024D", x => new { x.user_id, x.shop_id });
                    table.ForeignKey(
                        name: "FK__UserShops__shop___59063A47",
                        column: x => x.shop_id,
                        principalTable: "Shop",
                        principalColumn: "shop_id");
                    table.ForeignKey(
                        name: "FK__UserShops__user___5812160E",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "PollAnswer",
                columns: table => new
                {
                    answer_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    option_id = table.Column<int>(type: "int", nullable: false),
                    poll_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PollAnsw__CF62164BAC258F83", x => new { x.answer_id, x.user_id, x.option_id, x.poll_id });
                    table.ForeignKey(
                        name: "FK__PollAnswe__user___3C69FB99",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__PollAnswer__3D5E1FD2",
                        columns: x => new { x.option_id, x.poll_id },
                        principalTable: "PollOption",
                        principalColumns: new[] { "option_id", "poll_id" });
                });

            migrationBuilder.CreateTable(
                name: "SNT_event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false),
                    snt_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    event_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    event_name = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false),
                    event_location = table.Column<string>(type: "char(256)", unicode: false, fixedLength: true, maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SNT_even__5887A9A785F2421A", x => new { x.event_id, x.snt_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__SNT_event__4BAC3F29",
                        columns: x => new { x.snt_id, x.user_id },
                        principalTable: "SNT",
                        principalColumns: new[] { "snt_id", "user_id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_user_id",
                table: "Announcements",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Feeding_schedule_animals_id",
                table: "Feeding_schedule",
                column: "animals_id");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilization_plant_id",
                table: "Fertilization",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Harvest_plant_id",
                table: "Harvest",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Message_user_id",
                table: "Message",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_News_user_id",
                table: "News",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_user_id",
                table: "Payments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_plant_id",
                table: "Planting",
                column: "plant_id");

            migrationBuilder.CreateIndex(
                name: "IX_PollAnswer_option_id_poll_id",
                table: "PollAnswer",
                columns: new[] { "option_id", "poll_id" });

            migrationBuilder.CreateIndex(
                name: "IX_PollAnswer_user_id",
                table: "PollAnswer",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PollOption_poll_id",
                table: "PollOption",
                column: "poll_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_in_shop_shop_id",
                table: "Product_in_shop",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_SNT_user_id",
                table: "SNT",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_SNT_event_snt_id_user_id",
                table: "SNT_event",
                columns: new[] { "snt_id", "user_id" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnimals_animals_id",
                table: "UserAnimals",
                column: "animals_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserPlants_user_id",
                table: "UserPlants",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserShops_shop_id",
                table: "UserShops",
                column: "shop_id");

            migrationBuilder.CreateIndex(
                name: "IX_WateringSchedule_plant_id",
                table: "WateringSchedule",
                column: "plant_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Feeding_schedule");

            migrationBuilder.DropTable(
                name: "Fertilization");

            migrationBuilder.DropTable(
                name: "Harvest");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Planting");

            migrationBuilder.DropTable(
                name: "PollAnswer");

            migrationBuilder.DropTable(
                name: "Product_in_shop");

            migrationBuilder.DropTable(
                name: "SNT_event");

            migrationBuilder.DropTable(
                name: "UserAnimals");

            migrationBuilder.DropTable(
                name: "UserPlants");

            migrationBuilder.DropTable(
                name: "UserShops");

            migrationBuilder.DropTable(
                name: "WateringSchedule");

            migrationBuilder.DropTable(
                name: "PollOption");

            migrationBuilder.DropTable(
                name: "SNT");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Shop");

            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "Poll");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
