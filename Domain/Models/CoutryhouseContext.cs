using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain.Models
{
    public partial class CoutryhouseContext : DbContext
    {
        public CoutryhouseContext()
        {
        }

        public CoutryhouseContext(DbContextOptions<CoutryhouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; } = null!;
        public virtual DbSet<Announcement> Announcements { get; set; } = null!;
        public virtual DbSet<FeedingSchedule> FeedingSchedules { get; set; } = null!;
        public virtual DbSet<Fertilization> Fertilizations { get; set; } = null!;
        public virtual DbSet<Harvest> Harvests { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<News> News { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Plant> Plants { get; set; } = null!;
        public virtual DbSet<Planting> Plantings { get; set; } = null!;
        public virtual DbSet<Poll> Polls { get; set; } = null!;
        public virtual DbSet<PollAnswer> PollAnswers { get; set; } = null!;
        public virtual DbSet<PollOption> PollOptions { get; set; } = null!;
        public virtual DbSet<ProductInShop> ProductInShops { get; set; } = null!;
        public virtual DbSet<Shop> Shops { get; set; } = null!;
        public virtual DbSet<Snt> Snts { get; set; } = null!;
        public virtual DbSet<SntEvent> SntEvents { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WateringSchedule> WateringSchedules { get; set; } = null!;

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.AnimalsId)
                    .HasName("PK__Animals__9DF80BFF8735FEBC");

                entity.Property(e => e.AnimalsId)
                    .ValueGeneratedNever()
                    .HasColumnName("animals_id");

                entity.Property(e => e.AnimalBirthDate)
                    .HasColumnType("date")
                    .HasColumnName("animal_birth_date");

                entity.Property(e => e.AnimalName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("animal_name")
                    .IsFixedLength();

                entity.Property(e => e.AnimalType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("animal_type")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasKey(e => new { e.AnnouncementsId, e.UserId })
                    .HasName("PK__Announce__160413B9DCAF2039");

                entity.Property(e => e.AnnouncementsId).HasColumnName("announcements_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.AnnouncementDate)
                    .HasColumnType("date")
                    .HasColumnName("announcement_date");

                entity.Property(e => e.AnnouncementDescription)
                    .HasColumnType("text")
                    .HasColumnName("announcement_description");

                entity.Property(e => e.AnnouncementTopic)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("announcement_topic")
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Announcem__user___534D60F1");
            });

            modelBuilder.Entity<FeedingSchedule>(entity =>
            {
                entity.HasKey(e => new { e.FeedingId, e.AnimalsId })
                    .HasName("PK__Feeding___847B1963D96CEC8A");

                entity.ToTable("Feeding_schedule");

                entity.Property(e => e.FeedingId).HasColumnName("feeding_id");

                entity.Property(e => e.AnimalsId).HasColumnName("animals_id");

                entity.Property(e => e.FeedingDate)
                    .HasColumnType("date")
                    .HasColumnName("feeding_date");

                entity.Property(e => e.FeedingTime).HasColumnName("feeding_time");

                entity.Property(e => e.FeedingType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("feeding_type")
                    .IsFixedLength();

                entity.HasOne(d => d.Animals)
                    .WithMany(p => p.FeedingSchedules)
                    .HasForeignKey(d => d.AnimalsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feeding_s__anima__5FB337D6");
            });

            modelBuilder.Entity<Fertilization>(entity =>
            {
                entity.HasKey(e => new { e.FertilizationId, e.PlantId })
                    .HasName("PK__Fertiliz__BD767B33E6118EA9");

                entity.ToTable("Fertilization");

                entity.Property(e => e.FertilizationId).HasColumnName("fertilization_id");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.FertilizationDate)
                    .HasColumnType("date")
                    .HasColumnName("fertilization_date");

                entity.Property(e => e.FertilizerName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("fertilizer_name")
                    .IsFixedLength();

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Fertilizations)
                    .HasForeignKey(d => d.PlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fertiliza__plant__31EC6D26");
            });

            modelBuilder.Entity<Harvest>(entity =>
            {
                entity.HasKey(e => new { e.HarvestId, e.PlantId })
                    .HasName("PK__Harvest__84D00DF6B396193D");

                entity.ToTable("Harvest");

                entity.Property(e => e.HarvestId).HasColumnName("harvest_id");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.HarvestDate)
                    .HasColumnType("date")
                    .HasColumnName("harvest_date");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Harvests)
                    .HasForeignKey(d => d.PlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Harvest__plant_i__34C8D9D1");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => new { e.MessageId, e.UserId })
                    .HasName("PK__Message__E0248D96283DA771");

                entity.ToTable("Message");

                entity.Property(e => e.MessageId).HasColumnName("message_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.MessageDate)
                    .HasColumnType("date")
                    .HasColumnName("message_date");

                entity.Property(e => e.MessageText)
                    .HasColumnType("text")
                    .HasColumnName("message_text");

                entity.Property(e => e.MessageTime).HasColumnName("message_time");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__user_id__4316F928");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => new { e.NewsId, e.UserId })
                    .HasName("PK__News__A7BC2FA8EB3AEB9F");

                entity.Property(e => e.NewsId).HasColumnName("news_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.NewsDate)
                    .HasColumnType("date")
                    .HasColumnName("news_date");

                entity.Property(e => e.NewsText)
                    .HasColumnType("text")
                    .HasColumnName("news_text");

                entity.Property(e => e.NewsTitle)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("news_title")
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__News__user_id__403A8C7D");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => new { e.PaymentsId, e.UserId })
                    .HasName("PK__Payments__2C80D27F130C2D2B");

                entity.Property(e => e.PaymentsId).HasColumnName("payments_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.PaymentAmount).HasColumnName("payment_amount");

                entity.Property(e => e.PaymentDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_date");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("payment_type")
                    .IsFixedLength();

                entity.Property(e => e.PenaltyAmount).HasColumnName("penalty_amount");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payments__user_i__45F365D3");
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.ToTable("Plant");

                entity.Property(e => e.PlantId)
                    .ValueGeneratedNever()
                    .HasColumnName("plant_id");

                entity.Property(e => e.PlantName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("plant_name")
                    .IsFixedLength();

                entity.Property(e => e.PlantType)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("plant_type")
                    .IsFixedLength();

                entity.HasMany(d => d.Users)
                    .WithMany(p => p.Plants)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserPlant",
                        l => l.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserPlant__user___29572725"),
                        r => r.HasOne<Plant>().WithMany().HasForeignKey("PlantId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserPlant__plant__286302EC"),
                        j =>
                        {
                            j.HasKey("PlantId", "UserId").HasName("PK__UserPlan__4EED50C4A1F71E2F");

                            j.ToTable("UserPlants");

                            j.IndexerProperty<int>("PlantId").HasColumnName("plant_id");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        });
            });

            modelBuilder.Entity<Planting>(entity =>
            {
                entity.HasKey(e => new { e.PlantingId, e.PlantId })
                    .HasName("PK__Planting__2FE4309A8E1E368F");

                entity.ToTable("Planting");

                entity.Property(e => e.PlantingId).HasColumnName("planting_id");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.PlantingDate)
                    .HasColumnType("date")
                    .HasColumnName("planting_date");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.Plantings)
                    .HasForeignKey(d => d.PlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Planting__plant___2C3393D0");
            });

            modelBuilder.Entity<Poll>(entity =>
            {
                entity.ToTable("Poll");

                entity.Property(e => e.PollId)
                    .ValueGeneratedNever()
                    .HasColumnName("poll_id");

                entity.Property(e => e.PollDate)
                    .HasColumnType("date")
                    .HasColumnName("poll_date");

                entity.Property(e => e.PollQuestion)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("poll_question")
                    .IsFixedLength();
            });

            modelBuilder.Entity<PollAnswer>(entity =>
            {
                entity.HasKey(e => new { e.AnswerId, e.UserId, e.OptionId, e.PollId })
                    .HasName("PK__PollAnsw__CF62164BAC258F83");

                entity.ToTable("PollAnswer");

                entity.Property(e => e.AnswerId).HasColumnName("answer_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.OptionId).HasColumnName("option_id");

                entity.Property(e => e.PollId).HasColumnName("poll_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PollAnswers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PollAnswe__user___3C69FB99");

                entity.HasOne(d => d.PollOption)
                    .WithMany(p => p.PollAnswers)
                    .HasForeignKey(d => new { d.OptionId, d.PollId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PollAnswer__3D5E1FD2");
            });

            modelBuilder.Entity<PollOption>(entity =>
            {
                entity.HasKey(e => new { e.OptionId, e.PollId })
                    .HasName("PK__PollOpti__8BB6231648088261");

                entity.ToTable("PollOption");

                entity.Property(e => e.OptionId).HasColumnName("option_id");

                entity.Property(e => e.PollId).HasColumnName("poll_id");

                entity.Property(e => e.OptionText)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("option_text")
                    .IsFixedLength();

                entity.HasOne(d => d.Poll)
                    .WithMany(p => p.PollOptions)
                    .HasForeignKey(d => d.PollId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PollOptio__poll___398D8EEE");
            });

            modelBuilder.Entity<ProductInShop>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ShopId })
                    .HasName("PK__Product___3DD2FC8DBB0179AE");

                entity.ToTable("Product_in_shop");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("product_name")
                    .IsFixedLength();

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ProductInShops)
                    .HasForeignKey(d => d.ShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product_i__shop___5070F446");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.ToTable("Shop");

                entity.Property(e => e.ShopId)
                    .ValueGeneratedNever()
                    .HasColumnName("shop_id");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("city")
                    .IsFixedLength();

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("house_number")
                    .IsFixedLength();

                entity.Property(e => e.ShopName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("shop_name")
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("street")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Snt>(entity =>
            {
                entity.HasKey(e => new { e.SntId, e.UserId })
                    .HasName("PK__SNT__BF75E806B81E5FF5");

                entity.ToTable("SNT");

                entity.Property(e => e.SntId).HasColumnName("snt_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.City)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("city")
                    .IsFixedLength();

                entity.Property(e => e.HouseNumber)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("house_number")
                    .IsFixedLength();

                entity.Property(e => e.ManagerFirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("manager_first_name")
                    .IsFixedLength();

                entity.Property(e => e.ManagerLastName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("manager_last_name")
                    .IsFixedLength();

                entity.Property(e => e.ManagerPhone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("manager_phone")
                    .IsFixedLength();

                entity.Property(e => e.SntName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("snt_name")
                    .IsFixedLength();

                entity.Property(e => e.Street)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("street")
                    .IsFixedLength();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Snts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SNT__user_id__48CFD27E");
            });

            modelBuilder.Entity<SntEvent>(entity =>
            {
                entity.HasKey(e => new { e.EventId, e.SntId, e.UserId })
                    .HasName("PK__SNT_even__5887A9A785F2421A");

                entity.ToTable("SNT_event");

                entity.Property(e => e.EventId).HasColumnName("event_id");

                entity.Property(e => e.SntId).HasColumnName("snt_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.EventDate)
                    .HasColumnType("datetime")
                    .HasColumnName("event_date");

                entity.Property(e => e.EventLocation)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("event_location")
                    .IsFixedLength();

                entity.Property(e => e.EventName)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("event_name")
                    .IsFixedLength();

                entity.HasOne(d => d.Snt)
                    .WithMany(p => p.SntEvents)
                    .HasForeignKey(d => new { d.SntId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SNT_event__4BAC3F29");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasColumnName("first_name")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasColumnName("last_name")
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(52)
                    .IsUnicode(false)
                    .HasColumnName("middle_name")
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasColumnName("username")
                    .IsFixedLength();

                entity.HasMany(d => d.Animals)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserAnimal",
                        l => l.HasOne<Animal>().WithMany().HasForeignKey("AnimalsId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserAnima__anima__5CD6CB2B"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserAnima__user___5BE2A6F2"),
                        j =>
                        {
                            j.HasKey("UserId", "AnimalsId").HasName("PK__UserAnim__5061B7B0CC4C6DB2");

                            j.ToTable("UserAnimals");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<int>("AnimalsId").HasColumnName("animals_id");
                        });

                entity.HasMany(d => d.Shops)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserShop",
                        l => l.HasOne<Shop>().WithMany().HasForeignKey("ShopId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserShops__shop___59063A47"),
                        r => r.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserShops__user___5812160E"),
                        j =>
                        {
                            j.HasKey("UserId", "ShopId").HasName("PK__UserShop__C36EB6770AEB024D");

                            j.ToTable("UserShops");

                            j.IndexerProperty<int>("UserId").HasColumnName("user_id");

                            j.IndexerProperty<int>("ShopId").HasColumnName("shop_id");
                        });
            });

            modelBuilder.Entity<WateringSchedule>(entity =>
            {
                entity.HasKey(e => new { e.WateringScheduleId, e.PlantId })
                    .HasName("PK__Watering__8FE115C83BABBAD8");

                entity.ToTable("WateringSchedule");

                entity.Property(e => e.WateringScheduleId).HasColumnName("watering_schedule_id");

                entity.Property(e => e.PlantId).HasColumnName("plant_id");

                entity.Property(e => e.WateringDate)
                    .HasColumnType("date")
                    .HasColumnName("watering_date");

                entity.Property(e => e.WateringTime).HasColumnName("watering_time");

                entity.HasOne(d => d.Plant)
                    .WithMany(p => p.WateringSchedules)
                    .HasForeignKey(d => d.PlantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WateringS__plant__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
