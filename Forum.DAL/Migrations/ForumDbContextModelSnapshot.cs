﻿// <auto-generated />
using System;
using Forum.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Forum.DAL.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    partial class ForumDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Forum.Core.Entities.File", b =>
                {
                    b.Property<long>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageID")
                        .HasColumnType("int");

                    b.HasKey("FileID");

                    b.HasIndex("MessageID");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Forum.Core.Entities.ImageProfile", b =>
                {
                    b.Property<int>("ImageProfileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageProfileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageProfilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageProfileID");

                    b.ToTable("ImageProfiles");
                });

            modelBuilder.Entity("Forum.Core.Entities.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MessageID1")
                        .HasColumnType("int");

                    b.Property<int>("MessageLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("TopicID")
                        .HasColumnType("bigint");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("MessageID");

                    b.HasIndex("MessageID1");

                    b.HasIndex("TopicID");

                    b.HasIndex("UserID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Forum.Core.Entities.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoleID");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Forum.Core.Entities.Topic", b =>
                {
                    b.Property<long>("TopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TopicID");

                    b.HasIndex("TopicName")
                        .IsUnique();

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Forum.Core.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("RegistredAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.HasIndex("EmailAddress", "NickName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.Property<long>("UserTopicsTopicID")
                        .HasColumnType("bigint");

                    b.Property<int>("UsersUserID")
                        .HasColumnType("int");

                    b.HasKey("UserTopicsTopicID", "UsersUserID");

                    b.HasIndex("UsersUserID");

                    b.ToTable("TopicUser");
                });

            modelBuilder.Entity("Forum.Core.Entities.File", b =>
                {
                    b.HasOne("Forum.Core.Entities.Message", null)
                        .WithMany("Files")
                        .HasForeignKey("MessageID");
                });

            modelBuilder.Entity("Forum.Core.Entities.Message", b =>
                {
                    b.HasOne("Forum.Core.Entities.Message", null)
                        .WithMany("Answers")
                        .HasForeignKey("MessageID1");

                    b.HasOne("Forum.Core.Entities.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicID");

                    b.HasOne("Forum.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum.Core.Entities.User", b =>
                {
                    b.HasOne("Forum.Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.HasOne("Forum.Core.Entities.Topic", null)
                        .WithMany()
                        .HasForeignKey("UserTopicsTopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forum.Core.Entities.Message", b =>
                {
                    b.Navigation("Answers");

                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
