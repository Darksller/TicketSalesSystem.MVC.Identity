﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSalesSystem.DAL.Migrations
{
	/// <inheritdoc />
	public partial class AppMig : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Airlines",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Airlines", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Airplane",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Speed = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Airplane", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "FlightsStatus",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_FlightsStatus", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "Routes",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DeparturePoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ArrivalPoint = table.Column<string>(type: "nvarchar(max)", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Routes", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "SeatTypes",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Count = table.Column<int>(type: "int", nullable: false),
					MaxCount = table.Column<int>(type: "int", nullable: false),
					AirplaneId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_SeatTypes", x => x.Id);
					table.ForeignKey(
						name: "FK_SeatTypes_Airplane_AirplaneId",
						column: x => x.AirplaneId,
						principalTable: "Airplane",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Flights",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					FlightStatusId = table.Column<int>(type: "int", nullable: false),
					RouteId = table.Column<int>(type: "int", nullable: false),
					AirplaneId = table.Column<int>(type: "int", nullable: false),
					AirlineId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Flights", x => x.Id);
					table.ForeignKey(
						name: "FK_Flights_Airlines_AirlineId",
						column: x => x.AirlineId,
						principalTable: "Airlines",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Flights_Airplane_AirplaneId",
						column: x => x.AirplaneId,
						principalTable: "Airplane",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Flights_FlightsStatus_FlightStatusId",
						column: x => x.FlightStatusId,
						principalTable: "FlightsStatus",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Flights_Routes_RouteId",
						column: x => x.RouteId,
						principalTable: "Routes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "Tickets",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Place = table.Column<int>(type: "int", nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
					UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
					FlightId = table.Column<int>(type: "int", nullable: false),
					SeatTypeId = table.Column<int>(type: "int", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Tickets", x => x.Id);
					table.ForeignKey(
						name: "FK_Tickets_Flights_FlightId",
						column: x => x.FlightId,
						principalTable: "Flights",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Tickets_AspNetUsers_UserId",
						column: x => x.UserId,
						principalTable: "AspNetUsers",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Tickets_SeatTypes_SeatTypeId",
						column: x => x.SeatTypeId,
						principalTable: "SeatTypes",
						principalColumn: "Id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_Flights_AirlineId",
				table: "Flights",
				column: "AirlineId");

			migrationBuilder.CreateIndex(
				name: "IX_Flights_AirplaneId",
				table: "Flights",
				column: "AirplaneId");

			migrationBuilder.CreateIndex(
				name: "IX_Flights_FlightStatusId",
				table: "Flights",
				column: "FlightStatusId");

			migrationBuilder.CreateIndex(
				name: "IX_Flights_RouteId",
				table: "Flights",
				column: "RouteId");

			migrationBuilder.CreateIndex(
				name: "IX_SeatTypes_AirplaneId",
				table: "SeatTypes",
				column: "AirplaneId");

			migrationBuilder.CreateIndex(
				name: "IX_Tickets_FlightId",
				table: "Tickets",
				column: "FlightId");

			migrationBuilder.CreateIndex(
				name: "IX_Tickets_SeatTypeId",
				table: "Tickets",
				column: "SeatTypeId");

			migrationBuilder.CreateIndex(
				name: "IX_Tickets_UserId",
				table: "Tickets",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Tickets");

			migrationBuilder.DropTable(
				name: "Flights");

			migrationBuilder.DropTable(
				name: "SeatTypes");

			migrationBuilder.DropTable(
				name: "Airlines");

			migrationBuilder.DropTable(
				name: "FlightsStatus");

			migrationBuilder.DropTable(
				name: "Routes");

			migrationBuilder.DropTable(
				name: "Airplane");
		}
	}
}
