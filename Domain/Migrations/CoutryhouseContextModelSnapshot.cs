﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(CoutryhouseContext))]
    partial class CoutryhouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Animal", b =>
                {
                    b.Property<int>("AnimalsId")
                        .HasColumnType("int")
                        .HasColumnName("animals_id");

                    b.Property<DateTime?>("AnimalBirthDate")
                        .HasColumnType("date")
                        .HasColumnName("animal_birth_date");

                    b.Property<string>("AnimalName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("animal_name")
                        .IsFixedLength();

                    b.Property<string>("AnimalType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("animal_type")
                        .IsFixedLength();

                    b.HasKey("AnimalsId")
                        .HasName("PK__Animals__9DF80BFF8735FEBC");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("Domain.Models.Announcement", b =>
                {
                    b.Property<int>("AnnouncementsId")
                        .HasColumnType("int")
                        .HasColumnName("announcements_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("AnnouncementDate")
                        .HasColumnType("date")
                        .HasColumnName("announcement_date");

                    b.Property<string>("AnnouncementDescription")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("announcement_description");

                    b.Property<string>("AnnouncementTopic")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("announcement_topic")
                        .IsFixedLength();

                    b.HasKey("AnnouncementsId", "UserId")
                        .HasName("PK__Announce__160413B9DCAF2039");

                    b.HasIndex("UserId");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("Domain.Models.FeedingSchedule", b =>
                {
                    b.Property<int>("FeedingId")
                        .HasColumnType("int")
                        .HasColumnName("feeding_id");

                    b.Property<int>("AnimalsId")
                        .HasColumnType("int")
                        .HasColumnName("animals_id");

                    b.Property<DateTime>("FeedingDate")
                        .HasColumnType("date")
                        .HasColumnName("feeding_date");

                    b.Property<TimeSpan>("FeedingTime")
                        .HasColumnType("time")
                        .HasColumnName("feeding_time");

                    b.Property<string>("FeedingType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("feeding_type")
                        .IsFixedLength();

                    b.HasKey("FeedingId", "AnimalsId")
                        .HasName("PK__Feeding___847B1963D96CEC8A");

                    b.HasIndex("AnimalsId");

                    b.ToTable("Feeding_schedule", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Fertilization", b =>
                {
                    b.Property<int>("FertilizationId")
                        .HasColumnType("int")
                        .HasColumnName("fertilization_id");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<DateTime>("FertilizationDate")
                        .HasColumnType("date")
                        .HasColumnName("fertilization_date");

                    b.Property<string>("FertilizerName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("fertilizer_name")
                        .IsFixedLength();

                    b.HasKey("FertilizationId", "PlantId")
                        .HasName("PK__Fertiliz__BD767B33E6118EA9");

                    b.HasIndex("PlantId");

                    b.ToTable("Fertilization", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Harvest", b =>
                {
                    b.Property<int>("HarvestId")
                        .HasColumnType("int")
                        .HasColumnName("harvest_id");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<DateTime>("HarvestDate")
                        .HasColumnType("date")
                        .HasColumnName("harvest_date");

                    b.HasKey("HarvestId", "PlantId")
                        .HasName("PK__Harvest__84D00DF6B396193D");

                    b.HasIndex("PlantId");

                    b.ToTable("Harvest", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .HasColumnType("int")
                        .HasColumnName("message_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("date")
                        .HasColumnName("message_date");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("message_text");

                    b.Property<TimeSpan>("MessageTime")
                        .HasColumnType("time")
                        .HasColumnName("message_time");

                    b.HasKey("MessageId", "UserId")
                        .HasName("PK__Message__E0248D96283DA771");

                    b.HasIndex("UserId");

                    b.ToTable("Message", (string)null);
                });

            modelBuilder.Entity("Domain.Models.News", b =>
                {
                    b.Property<int>("NewsId")
                        .HasColumnType("int")
                        .HasColumnName("news_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("NewsDate")
                        .HasColumnType("date")
                        .HasColumnName("news_date");

                    b.Property<string>("NewsText")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("news_text");

                    b.Property<string>("NewsTitle")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("news_title")
                        .IsFixedLength();

                    b.HasKey("NewsId", "UserId")
                        .HasName("PK__News__A7BC2FA8EB3AEB9F");

                    b.HasIndex("UserId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("Domain.Models.Payment", b =>
                {
                    b.Property<int>("PaymentsId")
                        .HasColumnType("int")
                        .HasColumnName("payments_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("PaymentAmount")
                        .HasColumnType("int")
                        .HasColumnName("payment_amount");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date")
                        .HasColumnName("payment_date");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("payment_type")
                        .IsFixedLength();

                    b.Property<int?>("PenaltyAmount")
                        .HasColumnType("int")
                        .HasColumnName("penalty_amount");

                    b.HasKey("PaymentsId", "UserId")
                        .HasName("PK__Payments__2C80D27F130C2D2B");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Domain.Models.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<string>("PlantName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("char(255)")
                        .HasColumnName("plant_name")
                        .IsFixedLength();

                    b.Property<string>("PlantType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("char(255)")
                        .HasColumnName("plant_type")
                        .IsFixedLength();

                    b.HasKey("PlantId");

                    b.ToTable("Plant", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Planting", b =>
                {
                    b.Property<int>("PlantingId")
                        .HasColumnType("int")
                        .HasColumnName("planting_id");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<DateTime>("PlantingDate")
                        .HasColumnType("date")
                        .HasColumnName("planting_date");

                    b.HasKey("PlantingId", "PlantId")
                        .HasName("PK__Planting__2FE4309A8E1E368F");

                    b.HasIndex("PlantId");

                    b.ToTable("Planting", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Poll", b =>
                {
                    b.Property<int>("PollId")
                        .HasColumnType("int")
                        .HasColumnName("poll_id");

                    b.Property<DateTime>("PollDate")
                        .HasColumnType("date")
                        .HasColumnName("poll_date");

                    b.Property<string>("PollQuestion")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("poll_question")
                        .IsFixedLength();

                    b.HasKey("PollId");

                    b.ToTable("Poll", (string)null);
                });

            modelBuilder.Entity("Domain.Models.PollAnswer", b =>
                {
                    b.Property<int>("AnswerId")
                        .HasColumnType("int")
                        .HasColumnName("answer_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("OptionId")
                        .HasColumnType("int")
                        .HasColumnName("option_id");

                    b.Property<int>("PollId")
                        .HasColumnType("int")
                        .HasColumnName("poll_id");

                    b.HasKey("AnswerId", "UserId", "OptionId", "PollId")
                        .HasName("PK__PollAnsw__CF62164BAC258F83");

                    b.HasIndex("UserId");

                    b.HasIndex("OptionId", "PollId");

                    b.ToTable("PollAnswer", (string)null);
                });

            modelBuilder.Entity("Domain.Models.PollOption", b =>
                {
                    b.Property<int>("OptionId")
                        .HasColumnType("int")
                        .HasColumnName("option_id");

                    b.Property<int>("PollId")
                        .HasColumnType("int")
                        .HasColumnName("poll_id");

                    b.Property<string>("OptionText")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("option_text")
                        .IsFixedLength();

                    b.HasKey("OptionId", "PollId")
                        .HasName("PK__PollOpti__8BB6231648088261");

                    b.HasIndex("PollId");

                    b.ToTable("PollOption", (string)null);
                });

            modelBuilder.Entity("Domain.Models.ProductInShop", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("ShopId")
                        .HasColumnType("int")
                        .HasColumnName("shop_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("product_name")
                        .IsFixedLength();

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int")
                        .HasColumnName("product_price");

                    b.HasKey("ProductId", "ShopId")
                        .HasName("PK__Product___3DD2FC8DBB0179AE");

                    b.HasIndex("ShopId");

                    b.ToTable("Product_in_shop", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .HasColumnType("int")
                        .HasColumnName("shop_id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("city")
                        .IsFixedLength();

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("house_number")
                        .IsFixedLength();

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("shop_name")
                        .IsFixedLength();

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("street")
                        .IsFixedLength();

                    b.HasKey("ShopId");

                    b.ToTable("Shop", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Snt", b =>
                {
                    b.Property<int>("SntId")
                        .HasColumnType("int")
                        .HasColumnName("snt_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("city")
                        .IsFixedLength();

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("house_number")
                        .IsFixedLength();

                    b.Property<string>("ManagerFirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("manager_first_name")
                        .IsFixedLength();

                    b.Property<string>("ManagerLastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("manager_last_name")
                        .IsFixedLength();

                    b.Property<string>("ManagerPhone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("char(12)")
                        .HasColumnName("manager_phone")
                        .IsFixedLength();

                    b.Property<string>("SntName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("snt_name")
                        .IsFixedLength();

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("street")
                        .IsFixedLength();

                    b.HasKey("SntId", "UserId")
                        .HasName("PK__SNT__BF75E806B81E5FF5");

                    b.HasIndex("UserId");

                    b.ToTable("SNT", (string)null);
                });

            modelBuilder.Entity("Domain.Models.SntEvent", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("event_id");

                    b.Property<int>("SntId")
                        .HasColumnType("int")
                        .HasColumnName("snt_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime")
                        .HasColumnName("event_date");

                    b.Property<string>("EventLocation")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("event_location")
                        .IsFixedLength();

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(false)
                        .HasColumnType("char(256)")
                        .HasColumnName("event_name")
                        .IsFixedLength();

                    b.HasKey("EventId", "SntId", "UserId")
                        .HasName("PK__SNT_even__5887A9A785F2421A");

                    b.HasIndex("SntId", "UserId");

                    b.ToTable("SNT_event", (string)null);
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(52)
                        .IsUnicode(false)
                        .HasColumnType("char(52)")
                        .HasColumnName("first_name")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(52)
                        .IsUnicode(false)
                        .HasColumnType("char(52)")
                        .HasColumnName("last_name")
                        .IsFixedLength();

                    b.Property<string>("MiddleName")
                        .HasMaxLength(52)
                        .IsUnicode(false)
                        .HasColumnType("char(52)")
                        .HasColumnName("middle_name")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("char(128)")
                        .HasColumnName("password")
                        .IsFixedLength();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(false)
                        .HasColumnType("char(128)")
                        .HasColumnName("username")
                        .IsFixedLength();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.WateringSchedule", b =>
                {
                    b.Property<int>("WateringScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("watering_schedule_id");

                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<DateTime>("WateringDate")
                        .HasColumnType("date")
                        .HasColumnName("watering_date");

                    b.Property<TimeSpan>("WateringTime")
                        .HasColumnType("time")
                        .HasColumnName("watering_time");

                    b.HasKey("WateringScheduleId", "PlantId")
                        .HasName("PK__Watering__8FE115C83BABBAD8");

                    b.HasIndex("PlantId");

                    b.ToTable("WateringSchedule", (string)null);
                });

            modelBuilder.Entity("UserAnimal", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("AnimalsId")
                        .HasColumnType("int")
                        .HasColumnName("animals_id");

                    b.HasKey("UserId", "AnimalsId")
                        .HasName("PK__UserAnim__5061B7B0CC4C6DB2");

                    b.HasIndex("AnimalsId");

                    b.ToTable("UserAnimals", (string)null);
                });

            modelBuilder.Entity("UserPlant", b =>
                {
                    b.Property<int>("PlantId")
                        .HasColumnType("int")
                        .HasColumnName("plant_id");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("PlantId", "UserId")
                        .HasName("PK__UserPlan__4EED50C4A1F71E2F");

                    b.HasIndex("UserId");

                    b.ToTable("UserPlants", (string)null);
                });

            modelBuilder.Entity("UserShop", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<int>("ShopId")
                        .HasColumnType("int")
                        .HasColumnName("shop_id");

                    b.HasKey("UserId", "ShopId")
                        .HasName("PK__UserShop__C36EB6770AEB024D");

                    b.HasIndex("ShopId");

                    b.ToTable("UserShops", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Announcement", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Announcements")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Announcem__user___534D60F1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.FeedingSchedule", b =>
                {
                    b.HasOne("Domain.Models.Animal", "Animals")
                        .WithMany("FeedingSchedules")
                        .HasForeignKey("AnimalsId")
                        .IsRequired()
                        .HasConstraintName("FK__Feeding_s__anima__5FB337D6");

                    b.Navigation("Animals");
                });

            modelBuilder.Entity("Domain.Models.Fertilization", b =>
                {
                    b.HasOne("Domain.Models.Plant", "Plant")
                        .WithMany("Fertilizations")
                        .HasForeignKey("PlantId")
                        .IsRequired()
                        .HasConstraintName("FK__Fertiliza__plant__31EC6D26");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("Domain.Models.Harvest", b =>
                {
                    b.HasOne("Domain.Models.Plant", "Plant")
                        .WithMany("Harvests")
                        .HasForeignKey("PlantId")
                        .IsRequired()
                        .HasConstraintName("FK__Harvest__plant_i__34C8D9D1");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("Domain.Models.Message", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Messages")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Message__user_id__4316F928");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.News", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__News__user_id__403A8C7D");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Payment", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Payments")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__Payments__user_i__45F365D3");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.Planting", b =>
                {
                    b.HasOne("Domain.Models.Plant", "Plant")
                        .WithMany("Plantings")
                        .HasForeignKey("PlantId")
                        .IsRequired()
                        .HasConstraintName("FK__Planting__plant___2C3393D0");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("Domain.Models.PollAnswer", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("PollAnswers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__PollAnswe__user___3C69FB99");

                    b.HasOne("Domain.Models.PollOption", "PollOption")
                        .WithMany("PollAnswers")
                        .HasForeignKey("OptionId", "PollId")
                        .IsRequired()
                        .HasConstraintName("FK__PollAnswer__3D5E1FD2");

                    b.Navigation("PollOption");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.PollOption", b =>
                {
                    b.HasOne("Domain.Models.Poll", "Poll")
                        .WithMany("PollOptions")
                        .HasForeignKey("PollId")
                        .IsRequired()
                        .HasConstraintName("FK__PollOptio__poll___398D8EEE");

                    b.Navigation("Poll");
                });

            modelBuilder.Entity("Domain.Models.ProductInShop", b =>
                {
                    b.HasOne("Domain.Models.Shop", "Shop")
                        .WithMany("ProductInShops")
                        .HasForeignKey("ShopId")
                        .IsRequired()
                        .HasConstraintName("FK__Product_i__shop___5070F446");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Domain.Models.Snt", b =>
                {
                    b.HasOne("Domain.Models.User", "User")
                        .WithMany("Snts")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__SNT__user_id__48CFD27E");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Models.SntEvent", b =>
                {
                    b.HasOne("Domain.Models.Snt", "Snt")
                        .WithMany("SntEvents")
                        .HasForeignKey("SntId", "UserId")
                        .IsRequired()
                        .HasConstraintName("FK__SNT_event__4BAC3F29");

                    b.Navigation("Snt");
                });

            modelBuilder.Entity("Domain.Models.WateringSchedule", b =>
                {
                    b.HasOne("Domain.Models.Plant", "Plant")
                        .WithMany("WateringSchedules")
                        .HasForeignKey("PlantId")
                        .IsRequired()
                        .HasConstraintName("FK__WateringS__plant__2F10007B");

                    b.Navigation("Plant");
                });

            modelBuilder.Entity("UserAnimal", b =>
                {
                    b.HasOne("Domain.Models.Animal", null)
                        .WithMany()
                        .HasForeignKey("AnimalsId")
                        .IsRequired()
                        .HasConstraintName("FK__UserAnima__anima__5CD6CB2B");

                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserAnima__user___5BE2A6F2");
                });

            modelBuilder.Entity("UserPlant", b =>
                {
                    b.HasOne("Domain.Models.Plant", null)
                        .WithMany()
                        .HasForeignKey("PlantId")
                        .IsRequired()
                        .HasConstraintName("FK__UserPlant__plant__286302EC");

                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserPlant__user___29572725");
                });

            modelBuilder.Entity("UserShop", b =>
                {
                    b.HasOne("Domain.Models.Shop", null)
                        .WithMany()
                        .HasForeignKey("ShopId")
                        .IsRequired()
                        .HasConstraintName("FK__UserShops__shop___59063A47");

                    b.HasOne("Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserShops__user___5812160E");
                });

            modelBuilder.Entity("Domain.Models.Animal", b =>
                {
                    b.Navigation("FeedingSchedules");
                });

            modelBuilder.Entity("Domain.Models.Plant", b =>
                {
                    b.Navigation("Fertilizations");

                    b.Navigation("Harvests");

                    b.Navigation("Plantings");

                    b.Navigation("WateringSchedules");
                });

            modelBuilder.Entity("Domain.Models.Poll", b =>
                {
                    b.Navigation("PollOptions");
                });

            modelBuilder.Entity("Domain.Models.PollOption", b =>
                {
                    b.Navigation("PollAnswers");
                });

            modelBuilder.Entity("Domain.Models.Shop", b =>
                {
                    b.Navigation("ProductInShops");
                });

            modelBuilder.Entity("Domain.Models.Snt", b =>
                {
                    b.Navigation("SntEvents");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Announcements");

                    b.Navigation("Messages");

                    b.Navigation("News");

                    b.Navigation("Payments");

                    b.Navigation("PollAnswers");

                    b.Navigation("Snts");
                });
#pragma warning restore 612, 618
        }
    }
}
