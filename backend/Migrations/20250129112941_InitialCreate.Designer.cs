﻿// <auto-generated />
using System;
using BookSphereAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookSphereAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250129112941_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("BookSphereAPI.Models.AppNotification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("AppNotifications");
                });

            modelBuilder.Entity("BookSphereAPI.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BookClubId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookId");

                    b.HasIndex("BookClubId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            Author = "George Orwell",
                            BookClubId = 1,
                            Genre = "Dystopian",
                            Title = "1984"
                        },
                        new
                        {
                            BookId = 2,
                            Author = "Harper Lee",
                            BookClubId = 1,
                            Genre = "Fiction",
                            Title = "To Kill a Mockingbird"
                        });
                });

            modelBuilder.Entity("BookSphereAPI.Models.BookClub", b =>
                {
                    b.Property<int>("BookClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BookClubId");

                    b.ToTable("BookClubs");

                    b.HasData(
                        new
                        {
                            BookClubId = 1,
                            Description = "A book club for classic literature enthusiasts",
                            IsPublic = true,
                            Name = "Classic Readers"
                        });
                });

            modelBuilder.Entity("BookSphereAPI.Models.BookDiscussion", b =>
                {
                    b.Property<int>("DiscussionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookClubId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DiscussionId");

                    b.HasIndex("BookClubId");

                    b.ToTable("BookDiscussions");
                });

            modelBuilder.Entity("BookSphereAPI.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookClubId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxParticipants")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.HasIndex("BookClubId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("BookSphereAPI.Models.EventUserRelation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "EventId");

                    b.HasIndex("EventId");

                    b.ToTable("EventUserRelations");
                });

            modelBuilder.Entity("BookSphereAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@example.com",
                            HashedPassword = "hashedpassword123",
                            UserName = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "user1@example.com",
                            HashedPassword = "user1hashedpassword",
                            UserName = "User1"
                        });
                });

            modelBuilder.Entity("BookSphereAPI.Models.UserBookClubRelation", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookClubId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "BookClubId");

                    b.HasIndex("BookClubId");

                    b.ToTable("UserBookClubRelations");
                });

            modelBuilder.Entity("BookSphereAPI.Models.AppNotification", b =>
                {
                    b.HasOne("BookSphereAPI.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookSphereAPI.Models.Book", b =>
                {
                    b.HasOne("BookSphereAPI.Models.BookClub", "BookClub")
                        .WithMany("Books")
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");
                });

            modelBuilder.Entity("BookSphereAPI.Models.BookDiscussion", b =>
                {
                    b.HasOne("BookSphereAPI.Models.BookClub", "BookClub")
                        .WithMany("Discussions")
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");
                });

            modelBuilder.Entity("BookSphereAPI.Models.Event", b =>
                {
                    b.HasOne("BookSphereAPI.Models.BookClub", null)
                        .WithMany("Events")
                        .HasForeignKey("BookClubId");
                });

            modelBuilder.Entity("BookSphereAPI.Models.EventUserRelation", b =>
                {
                    b.HasOne("BookSphereAPI.Models.Event", "Event")
                        .WithMany("EventUserRelations")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookSphereAPI.Models.User", "User")
                        .WithMany("EventUserRelations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookSphereAPI.Models.UserBookClubRelation", b =>
                {
                    b.HasOne("BookSphereAPI.Models.BookClub", "BookClub")
                        .WithMany("UserRelations")
                        .HasForeignKey("BookClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookSphereAPI.Models.User", "User")
                        .WithMany("UserBookClubs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookClub");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookSphereAPI.Models.BookClub", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Discussions");

                    b.Navigation("Events");

                    b.Navigation("UserRelations");
                });

            modelBuilder.Entity("BookSphereAPI.Models.Event", b =>
                {
                    b.Navigation("EventUserRelations");
                });

            modelBuilder.Entity("BookSphereAPI.Models.User", b =>
                {
                    b.Navigation("EventUserRelations");

                    b.Navigation("Notifications");

                    b.Navigation("UserBookClubs");
                });
#pragma warning restore 612, 618
        }
    }
}
