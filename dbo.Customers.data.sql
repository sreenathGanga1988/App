SET IDENTITY_INSERT [dbo].[Customers] ON
INSERT INTO [dbo].[Customers] ([CustomerID], [StoreID], [CustomerName], [PhoneNumber], [CustomerDetails], [Color]) VALUES (1, 1, N'New', N'0557364902', N'test', NULL)
INSERT INTO [dbo].[Customers] ([CustomerID], [StoreID], [CustomerName], [PhoneNumber], [CustomerDetails], [Color]) VALUES (6, 1, N'Prakash', N'0557364902', N'test', NULL)
INSERT INTO [dbo].[Customers] ([CustomerID], [StoreID], [CustomerName], [PhoneNumber], [CustomerDetails], [Color]) VALUES (7, 1, N'ravi', N'na', N'na', NULL)
SET IDENTITY_INSERT [dbo].[Customers] OFF
