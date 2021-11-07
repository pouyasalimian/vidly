namespace Vidly3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2b7b7e44-715b-478b-ab98-ba77c756afd5', N'guest@vidly.com', 0, N'AE7aMu79ivp1nVLCE2aLWqh8AjxjsjsW6iP6iLNgiB1amg6lkQ+btG4msbpiky3LdA==', N'33d17ce3-b13b-4559-811e-dffd707cc5d2', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bd2229f2-3ed6-46a6-a784-ae688aa62e29', N'p.salimian007@gmail.com', 0, N'AJoNaXImd5XPYo2ln/pRFCq8V9oUlKN/lg7U5pnNDnNAIcuQKQXBlGGpBSEu35HVhw==', N'debfc987-9aee-4ade-86cf-93475d97a99f', NULL, 0, 0, NULL, 1, 0, N'p.salimian007@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e49b80a0-fd5a-4071-8b6b-99e06975cb77', N'admin@vidly.com', 0, N'AH+4TN+6wahi+1JG1DuyRndEVex05blEPK5GL9rimNpFzFHSGmelXz3oerPaDGx9wA==', N'6d4729f2-dc5a-4b46-a03d-875847ff2a61', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fc368258-1eef-470e-ab1d-1b657704bf5f', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e49b80a0-fd5a-4071-8b6b-99e06975cb77', N'fc368258-1eef-470e-ab1d-1b657704bf5f')

");
        }
        
        public override void Down()
        {
        }
    }
}
