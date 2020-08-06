Imports System
Imports System.Data.Entity
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Linq

Partial Public Class AssignmentDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=AssignmentDbContext1")
    End Sub

    Public Overridable Property Campaigns As DbSet(Of Campaign)
    Public Overridable Property Categories As DbSet(Of Category)
    Public Overridable Property Comments As DbSet(Of Comment)
    Public Overridable Property Coupons As DbSet(Of Coupon)
    Public Overridable Property Members As DbSet(Of Member)
    Public Overridable Property Orders As DbSet(Of Order)
    Public Overridable Property Owners As DbSet(Of Owner)
    Public Overridable Property Products As DbSet(Of Product)
    Public Overridable Property Product_Order As DbSet(Of Product_Order)
    Public Overridable Property Promotions As DbSet(Of Promotion)
    Public Overridable Property Users As DbSet(Of User)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of Category)() _
            .HasMany(Function(e) e.Category11) _
            .WithRequired(Function(e) e.Category2) _
            .HasForeignKey(Function(e) e.category1)

        modelBuilder.Entity(Of Category)() _
            .HasMany(Function(e) e.Products) _
            .WithRequired(Function(e) e.Category1) _
            .HasForeignKey(Function(e) e.category) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Comment)() _
            .HasMany(Function(e) e.Comment11) _
            .WithRequired(Function(e) e.Comment2) _
            .HasForeignKey(Function(e) e.replyTo)

        modelBuilder.Entity(Of Member)() _
            .HasMany(Function(e) e.Comments) _
            .WithRequired(Function(e) e.Member) _
            .HasForeignKey(Function(e) e.creator) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Member)() _
            .HasMany(Function(e) e.Orders) _
            .WithRequired(Function(e) e.Member1) _
            .HasForeignKey(Function(e) e.member) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Order)() _
            .Property(Function(e) e.total) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of Order)() _
            .HasMany(Function(e) e.Product_Order) _
            .WithRequired(Function(e) e.Order) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Owner)() _
            .HasMany(Function(e) e.Owner1) _
            .WithRequired(Function(e) e.Owner2) _
            .HasForeignKey(Function(e) e.superior)

        modelBuilder.Entity(Of Product)() _
            .Property(Function(e) e.price) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of Product)() _
            .HasMany(Function(e) e.Product_Order) _
            .WithRequired(Function(e) e.Product1) _
            .HasForeignKey(Function(e) e.product) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Product_Order)() _
            .Property(Function(e) e.price) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of Promotion)() _
            .Property(Function(e) e.discountRate) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of Promotion)() _
            .HasMany(Function(e) e.Campaigns) _
            .WithRequired(Function(e) e.Promotion) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Promotion)() _
            .HasMany(Function(e) e.Coupons) _
            .WithRequired(Function(e) e.Promotion) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of Promotion)() _
            .HasMany(Function(e) e.Orders) _
            .WithRequired(Function(e) e.Promotion) _
            .HasForeignKey(Function(e) e.grantedPromotion) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of User)() _
            .HasMany(Function(e) e.Members) _
            .WithRequired(Function(e) e.User) _
            .WillCascadeOnDelete(False)

        modelBuilder.Entity(Of User)() _
            .HasMany(Function(e) e.Owners) _
            .WithRequired(Function(e) e.User) _
            .WillCascadeOnDelete(False)
    End Sub
End Class
