using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebFormsCommerceDemo.Models
{
	public class DbInitializer : CreateDatabaseIfNotExists<SrvContext>
	{
		protected override void Seed(SrvContext context)
		{
			GetCategories().ForEach(c => context.Categories.Add(c));
			GetProducts().ForEach(p => context.Products.Add(p));
			GetCustomers().ForEach(c => context.Customers.Add(c));
			GetOrders().ForEach(o => context.Orders.Add(o));
			GetCartItems().ForEach(ci => context.CartItems.Add(ci));
		}

		private static List<Category> GetCategories()
		{
			var categories = new List<Category> {
								new Category
								{
									CategoryID = 1,
									Name = "Desktop HDD"
								},
								new Category
								{
									CategoryID = 2,
									Name = "Laptop HDD"
								},
								new Category
								{
									CategoryID = 3,
									Name = "Laptop SSD"
								},
								new Category
								{
									CategoryID = 4,
									Name = "Portable"
								},
								new Category
								{
									CategoryID = 5,
									Name = "Network Storage"
								},
								new Category
								{
									CategoryID = 6,
									Name = "Zip Drives"
								},
								new Category
								{
									CategoryID = 7,
									Name = "Tape Storage"
								}
						};
			return categories;
		}

		private static List<Product> GetProducts()
		{
			var products = new List<Product> {
								new Product
								{
									ProductID = 1,
									Name = "Seagate Expansion 8TB",
									Description = "<p>The Seagate Expansion desktop drive provides extra storage for your ever-growing collection of files. Instantly add space for more files, consolidate all of your files to a single location, or free up space on your computer's internal drive to help improve performance.</p>",
									ImagePath = "/uploads/ProductImages/22-178-951-01.jpg",
									UnitPrice = 219.95,
									IsAvailable = true,
									IsFeatured = true,
									CategoryID = 1
								},
								new Product
								{
									ProductID = 2,
									Name = "WD Black 5TB Performance Desktop Hard Disk Drive - 7200 RPM SATA 6Gb/s 128MB Cache 3.5 Inch - WD5001FZWX",
									Description = "<p>2X DRAM cache up to 128MB (6TB, 5TB only) for faster read operations.</p>",
									ImagePath = "/uploads/ProductImages/22-236-971-14.jpg",
									UnitPrice = 189.99,
									IsAvailable = true,
									IsFeatured = true,
									CategoryID = 1
								},
								new Product
								{
									ProductID = 3,
									Name = "SAMSUNG 950 PRO M.2 2280 512GB PCI-Express 3.0 x4 Internal Solid State Drive (SSD) MZ-V5P512BW",
									Description = "<p>Samsung V-NAND Technology and PCIe 3.0 x 4, M.2 Gen 3.</p>",
									ImagePath = "/uploads/ProductImages/20-147-467-07.jpg",
									UnitPrice = 329.99,
									IsAvailable = true,
									IsFeatured = true,
									CategoryID = 3
								},
								new Product
								{
									ProductID = 4,
									Name = "HyperX Predator M.2 2280 480GB PCI-Express 2.0 x4 Internal Solid State Drive (SSD) SHPM2280P2/480G",
									Description = "<p>M.2 2280 480GB, PCI-Express 2.0 x4.</p>",
									ImagePath = "/uploads/ProductImages/20-104-543-02.jpg",
									UnitPrice = 341.99,
									IsAvailable = false,
									IsFeatured = false,
									CategoryID = 3
								},
								new Product
								{
									ProductID = 5,
									Name = "Corsair Neutron 240 GB 2.5&quot; Internal Solid State Drive CSSD-N240GBGTXB-BK",
									Description = "<p>Neutron Series GTX SSDs: extreme-performance solid-state drives.</p><p>Neutron Series GTX is our flagship line of SSDs, designed for high - end desktop and notebook PCs.Powered by an advanced Link_A_Media(LAMD) SATA 3 SSD controller, the GTX excels at both random read / write speeds and sequential write speeds, and provides amazing responsiveness for all types of data - intensive work.</p><p>Designed for Multi - Multi - Tasking; Neutron Series GTX is designed to support complex data - intensive work that involves accessing multiple files simultaneously - video production, large - scale graphics editing, or running multiple office applications at once.</p><p>Neutron GTX&#39;s extremely high random IOPS performance gives you the nearly instantaneous response you need for your high-end desktop or notebook PC.</p>",
									ImagePath = "/uploads/ProductImages/A6UM_130675353958918979i7E0PwjzSP.jpg",
									UnitPrice = 299,
									IsAvailable = true,
									IsFeatured = false,
									CategoryID = 3
								},
								new Product
								{
									ProductID = 6,
									Name = "BUFFALO LinkStation 410 2 TB High Performance NAS Personal Cloud Storage and Media Server - LS410D0201",
									Description = "<p>1-Bay, 1 x 10/100/1000M</p>",
									ImagePath = "/uploads/ProductImages/A91N_1_20151119571971395.jpg",
									UnitPrice = 184.99,
									IsAvailable = false,
									IsFeatured = true,
									CategoryID = 5
								},
								new Product
								{
									ProductID = 7,
									Name = "WD 3TB Blue My Passport Ultra Portable External Hard Drive - USB 3.0 - WDBBKD0030BBL-NESN",
									Description = "<p>Secure and dependable, My Passport Ultra can be trusted to safeguard your private files. Set an optional password, that only you know, to activate 256-bit hardware encryption to add an extra layer of security. Combined with WD Backup, our most powerful backup software yet, it&#39;s easier than ever to have a backup plan that fits your life.</p>",
									ImagePath = "/uploads/ProductImages/A19P_1_20160315654271355.jpg",
									UnitPrice = 119.0,
									IsAvailable = true,
									IsFeatured = true,
									CategoryID = 4
								},
								new Product
								{
									ProductID = 8,
									Name = "Kanguru Defender Elite300 4GB FIPS 140-2 Certified, SuperSpeed USB 3.0 Flash Drive 256bit AES Encryption Model KDFE300-4G-PRO",
									Description = "FIPS 140-2 Certified",
									ImagePath = "/uploads/ProductImages/A5UX_1_20151009542368338.jpg",
									UnitPrice = 69.9,
									IsAvailable = true,
									IsFeatured = true,
									CategoryID = 4
								},
								new Product
								{
									ProductID = 9,
									Name = "Visiontek Racer 240 GB 2.5\" Internal Solid State Drive - SATA - 555 MB/s Maximum Read Transfer Rate - 520 MB/s Maximum Write Transfer Rate",
									Description = "<p>Enable best-of-class performance in your personal PC with the VisionTek Racer Series SSD powered by the latest SandForce SF-2281 processor. The VisionTek Racer Series leads the market with ultra-fast 550MB/s plus read and write speeds.</p>",
									ImagePath = "/uploads/ProductImages/20-367-053-02.jpg",
									UnitPrice = 97.49,
									IsAvailable = true,
									IsFeatured = true,
									CategoryID = 3
								},
								new Product
								{
									ProductID = 10,
									CategoryID = 7,
									Name = "Quantum MR-L3MQN-01-20PK Blue 800GB LTO Ultrium 3 Tape Cartridge",
									Description = "<p>MR-L3MQN-01-20PK;<br />Compatible With<br />- Quantum LTO-3<br />- Quantum LTO-3 CL1101-SB<br />- Quantum LTO-3 CL1101-SST<br />- Quantum LTO-3 CL1102-SST<br />- Quantum LTO-3 HH<br />- Quantum LTO-3A Half Height<br />- Quantum LTO-4 HH<br />- Quantum LTO-4 HH SAS HBA bundle</p>",
									ImagePath = "/uploads/ProductImages/40-121-127-02.jpg",
									UnitPrice = 97.49,
									IsAvailable = true,
									IsFeatured = false
								}
						};
			return products;
		}

		private static List<Customer> GetCustomers()
		{
			var customers = new List<Customer> {
								new Customer
								{
									CustomerID = 1,
									UniqueKey = Guid.NewGuid(),
									Username="abhimani@hawk.iit.edu",
									FirstName = "Ankit",
									LastName = "Bhimani",
									BillingAddress = "200 Tennyson Parkway",
									BillingCity = "Dallas",
									BillingState = "TX",
									BillingZip = 60616,
									ShippingAddress = "200 Tennyson Parkway",
									ShippingCity = "Dallas",
									ShippingState = "TX",
									ShippingZip = 60616,
									Phone = 3125365229,
									PasswordBin = Generics.MakeHash("password1"),
									IsActive = true
								}
						};
			return customers;
		}

		private static List<Order> GetOrders()
		{
			var orders = new List<Order> {
								new Order
								{
									OrderID = 1,
									CustomerID = 1,
									UniqueOrderNumber = Guid.NewGuid(),
									OrderDate = new DateTime(2009, 8, 15),
									FirstName = "Ankit",
									LastName = "Bhimani",
									BillingAddress = "200 Tennyson Parkway",
									BillingCity = "Dallas",
									BillingState = "TX",
									BillingZip = 60616,
									ShippingAddress = "200 Tennyson Parkway",
									ShippingCity = "Dallas",
									ShippingState = "TX",
									ShippingZip = 60616,
									TaxSum = 16.74,
									TotalSum = 167.39,
									Notes = "Please ship my order items in 2 different boxes.",
									IsOrdered = true
								}
						};
			return orders;
		}

		private static List<CartItem> GetCartItems()
		{
			var cartitems = new List<CartItem> {
								new CartItem
								{
									CartItemID = 1,
									CustomerID = 1,
									ProductID = 8,
									Quantity = 1,
									ItemPrice = 69.9,
									IsActive = false,
									OrderID = 1
								},
								new CartItem
								{
									CartItemID = 2,
									CustomerID = 1,
									ProductID = 10,
									Quantity = 1,
									ItemPrice = 97.49,
									IsActive = false,
									OrderID = 1
								},
								new CartItem
								{
									CartItemID = 3,
									CustomerID = 1,
									ProductID = 8,
									Quantity = 2,
									ItemPrice = (69.9*2),
									IsActive = true
								}
						};
			return cartitems;
		}
	}
}
