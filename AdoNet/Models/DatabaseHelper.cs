using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace AdoNet.Models
{
    public class DatabaseHelper
    {
        public static string FSD_CONN_STRING = ConfigurationManager.ConnectionStrings["FSDConnection"].ConnectionString;
        public DataTable CategoryDataTable;
        public DataSet CategoryDataSet = new DataSet();
        public SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

        public DataTable CustomerDataTable;
        public DataSet CustomerDataSet = new DataSet();
        public SqlDataAdapter sqlCustDataAdapter = new SqlDataAdapter();

        #region commented
        public List<ProductDetails> GetProductDetails()
        {
            List<ProductDetails> lstProductDeatils = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("select * from Product_Details", connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    lstProductDeatils = new List<ProductDetails>();

                while (reader.Read())
                {
                    lstProductDeatils.Add(new ProductDetails
                    {
                        ProductId = int.Parse(reader["Product_Id"].ToString()),
                        ProductName = reader["Product_Name"].ToString(),
                        SupplierId = int.Parse(reader["Supplier_Id"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return lstProductDeatils;
        }

        public ProductDetails GetProductDetail(int productId)
        {
            ProductDetails productDetail = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("select * from Product_Details where product_id=@productId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = Convert.ToInt32(productId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    productDetail = new ProductDetails
                    {
                        ProductId = int.Parse(reader["Product_Id"].ToString()),
                        ProductName = reader["Product_Name"].ToString(),
                        SupplierId = int.Parse(reader["Supplier_Id"].ToString())
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return productDetail;
        }

        public int AddProduct(ProductDetails product)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Insert into Product_Details(Product_Id,Product_Name,Supplier_Id) values (@ProductId, @ProductName,@SupplierId)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = Convert.ToInt32(product.ProductId);
                command.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = product.ProductName;
                command.Parameters.Add("@SupplierId", SqlDbType.Int).Value = Convert.ToInt32(product.SupplierId);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public int EditProduct(ProductDetails product)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Update Product_Details set Product_Name = @ProductName, Supplier_Id = @SupplierId where Product_Id = @ProductId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = Convert.ToInt32(product.ProductId);
                command.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = product.ProductName;
                command.Parameters.Add("@SupplierId", SqlDbType.Int).Value = Convert.ToInt32(product.SupplierId);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public int DeleteProduct(int productId)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Delete from Product_Details where Product_Id = @ProductId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@ProductId", SqlDbType.Int).Value = Convert.ToInt32(productId);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }


        public List<SupplierInfo> GetSuppliersInfo()
        {
            List<SupplierInfo> lstSupplierInfo = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("select * from Supplier_Info", connection);
                command.CommandType = CommandType.Text;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    lstSupplierInfo = new List<SupplierInfo>();

                while (reader.Read())
                {
                    lstSupplierInfo.Add(new SupplierInfo
                    {
                        SupplierId = int.Parse(reader["Supplier_Id"].ToString()),
                        SupplierName = reader["Supplier_Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        ContactNo = int.Parse(reader["Contact_No"].ToString()),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return lstSupplierInfo;
        }

        public SupplierInfo GetSupplierInfo(int supplierId)
        {
            SupplierInfo supplierInfo = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("select * from Supplier_Info where supplier_id=@SupplierId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@SupplierId", SqlDbType.Int).Value = Convert.ToInt32(supplierId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    supplierInfo = new SupplierInfo
                    {
                        SupplierId = int.Parse(reader["Supplier_Id"].ToString()),
                        SupplierName = reader["Supplier_Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        ContactNo = int.Parse(reader["Contact_No"].ToString()),
                        Email = reader["Email"].ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return supplierInfo;
        }

        public int AddSupplier(SupplierInfo supplierInfo)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Insert into Supplier_Info(Supplier_Id,Supplier_Name,Address,City,Contact_No,Email) values (@SupplierId, @SupplierName,@Address,@City,@ContactNo,@Email)", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@SupplierId", SqlDbType.Int).Value = Convert.ToInt32(supplierInfo.SupplierId);
                command.Parameters.Add("@SupplierName", SqlDbType.VarChar).Value = supplierInfo.SupplierName;
                command.Parameters.Add("@Address", SqlDbType.VarChar).Value = supplierInfo.Address;
                command.Parameters.Add("@City", SqlDbType.VarChar).Value = supplierInfo.City;
                command.Parameters.Add("@ContactNo", SqlDbType.Int).Value = Convert.ToInt32(supplierInfo.ContactNo);
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = supplierInfo.Email;
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public int EditSupplier(SupplierInfo supplierInfo)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Update Supplier_Info set Supplier_Name = @SupplierName," +
                    "Address = @Address, City=@city,Contact_No =@ContactNo,Email=@Email " +
                    "where Supplier_Id = @SupplierId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@SupplierId", SqlDbType.Int).Value = Convert.ToInt32(supplierInfo.SupplierId);
                command.Parameters.Add("@SupplierName", SqlDbType.VarChar).Value = supplierInfo.SupplierName;
                command.Parameters.Add("@Address", SqlDbType.VarChar).Value = supplierInfo.Address;
                command.Parameters.Add("@City", SqlDbType.VarChar).Value = supplierInfo.City;
                command.Parameters.Add("@ContactNo", SqlDbType.Int).Value = Convert.ToInt32(supplierInfo.ContactNo);
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = supplierInfo.Email;
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public int DeleteSupplier(int supplierId)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("Delete from Supplier_Info where Supplier_Id = @SupplierId", connection);
                command.CommandType = CommandType.Text;
                command.Parameters.Add("@SupplierId", SqlDbType.Int).Value = Convert.ToInt32(supplierId);
                connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
        }

        public List<Category> GetCategory(string searchKey, string searchBy)
        {
            List<Category> lstCategory = new List<Category>();
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                string query = string.Format("select * from Category where {0} = @searchKey", searchBy);
                command = new SqlCommand(query, connection);
                command.CommandType = CommandType.Text;

                if (searchBy == "Supplier_Id" || searchBy == "Category_Code")
                    command.Parameters.Add("@searchKey", SqlDbType.Int).Value = int.Parse(searchKey);
                else
                    command.Parameters.Add("@searchKey", SqlDbType.VarChar, 50).Value = searchKey;

                connection.Open();

                ClearExistingRows();

                sqlDataAdapter.SelectCommand = command;
                sqlDataAdapter.Fill(CategoryDataSet);

                CategoryDataTable = CategoryDataSet.Tables[0];

                foreach (DataRow dr in CategoryDataTable.Rows)
                {
                    lstCategory.Add(new Category
                    {
                        CategoryCode = int.Parse(dr["Category_Code"].ToString()),
                        CategoryName = dr["Category_Name"].ToString(),
                        Division = dr["Division"].ToString(),
                        Region = dr["Region"].ToString(),
                        SupplierId = int.Parse(dr["Supplier_Id"].ToString()),
                        SupplierName = dr["Supplier_Name"].ToString(),
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
            }
            return lstCategory;
        }

        public Category GetCategoryByCode(int categoryCode)
        {
            Category category = null;
            if (CategoryDataTable.Rows.Count > 0)
            {
                var myRow = CategoryDataTable.Select("Category_Code=" + categoryCode).First();

                category = new Category
                {
                    CategoryCode = int.Parse(myRow["Category_Code"].ToString()),
                    CategoryName = myRow["Category_Name"].ToString(),
                    Division = myRow["Division"].ToString(),
                    Region = myRow["Region"].ToString(),
                    SupplierId = int.Parse(myRow["Supplier_Id"].ToString()),
                    SupplierName = myRow["Supplier_Name"].ToString(),
                };

                return category;
            }
            return null;
        }

        public int UpdateCategory(Category category, int oldCategoryCode)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(FSD_CONN_STRING);
                sqlDataAdapter.UpdateCommand = new SqlCommand("Update Category set Category_Code = @CategoryCode," +
                    "Category_Name = @CategoryName, Division = @Division, Region = @Region" +
                    " where Category_Code=@OldCategoryCode", connection);

                sqlDataAdapter.UpdateCommand.Parameters.Add("@CategoryCode", SqlDbType.Int).Value = category.CategoryCode;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@OldCategoryCode", SqlDbType.Int).Value = oldCategoryCode;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@CategoryName", SqlDbType.VarChar, 50).Value = category.CategoryName;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@Division", SqlDbType.VarChar, 50).Value = category.Division;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@Region", SqlDbType.VarChar, 50).Value = category.Region;

                var myRow = CategoryDataTable.Select("Category_Code=" + oldCategoryCode).First();
                myRow["Category_Code"] = category.CategoryCode;
                myRow["Category_Name"] = category.CategoryName;
                myRow["Division"] = category.Division;
                myRow["Region"] = category.Region;
                myRow["Supplier_Id"] = category.SupplierId;
                myRow["Supplier_Name"] = category.SupplierName;

                return sqlDataAdapter.Update(CategoryDataTable);
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }



        public List<Customer> GetAllCustomers()
        {
            List<Customer> lstCustomers = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("GetAllCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    lstCustomers = new List<Customer>();

                while (reader.Read())
                {
                    lstCustomers.Add(new Customer
                    {
                        CustomerId = reader["Customer_ID"].ToString(),
                        CustomerName = reader["Customer_Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"].ToString()).Date,
                        Salary = Convert.ToDouble(reader["Salary"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
            return lstCustomers;
        }

        public Customer GetCustomer(string customerId)
        {
            Customer customer = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("GetCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Customer_ID", SqlDbType.VarChar, 30).Value = customerId;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customer = new Customer()
                        {
                            CustomerId = reader["Customer_ID"].ToString(),
                            CustomerName = reader["Customer_Name"].ToString(),
                            Address = reader["Address"].ToString(),
                            DOB = Convert.ToDateTime(reader["DOB"].ToString()).Date,
                            Salary = Convert.ToDouble(reader["Salary"].ToString())
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
            return customer;
        }

        public int InsertCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("InsertCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Customer_Name", SqlDbType.VarChar, 50).Value = customer.CustomerName;
                command.Parameters.Add("@Address", SqlDbType.VarChar, 200).Value = customer.Address;
                command.Parameters.Add("@DOB", SqlDbType.Date).Value = customer.DOB.Date;
                command.Parameters.Add("@SALARY", SqlDbType.SmallMoney).Value = customer.Salary;
                connection.Open();

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
        }

        public int UpdateCustomer(Customer customer)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("UpdateCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Customer_ID", SqlDbType.VarChar, 30).Value = customer.CustomerId;
                command.Parameters.Add("@Customer_Name", SqlDbType.VarChar, 50).Value = customer.CustomerName;
                command.Parameters.Add("@Address", SqlDbType.VarChar, 200).Value = customer.Address;
                command.Parameters.Add("@DOB", SqlDbType.Date).Value = customer.DOB.Date;
                command.Parameters.Add("@SALARY", SqlDbType.SmallMoney).Value = customer.Salary;
                connection.Open();

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
        }

        public int DeleteCustomer(string customerId)
        {
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("DeleteCustomer", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Customer_ID", SqlDbType.VarChar, 30).Value = customerId;
                connection.Open();

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
        }

        public List<Customer> GetAllCustomersBornAfter(DateTime dob)
        {
            List<Customer> lstCustomers = null;
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                command = new SqlCommand("GetCustomersAfterGivenDOB", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@DOB", SqlDbType.Date).Value = dob.Date;
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    lstCustomers = new List<Customer>();

                while (reader.Read())
                {
                    lstCustomers.Add(new Customer
                    {
                        CustomerId = reader["Customer_ID"].ToString(),
                        CustomerName = reader["Customer_Name"].ToString(),
                        Address = reader["Address"].ToString(),
                        DOB = Convert.ToDateTime(reader["DOB"].ToString()).Date,
                        Salary = Convert.ToDouble(reader["Salary"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
            return lstCustomers;
        }

        #endregion

        public List<Customer> GetAllCustomersDS()
        {
            List<Customer> lstCustomers = new List<Customer>();
            SqlConnection connection = new SqlConnection(FSD_CONN_STRING);
            SqlCommand command = null;
            try
            {
                if (CustomerDataSet.Tables.Count == 0)
                {
                    command = new SqlCommand("GetAllCustomer", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    
                    sqlCustDataAdapter.SelectCommand = command;
                    sqlCustDataAdapter.Fill(CustomerDataSet);

                    CustomerDataTable = CustomerDataSet.Tables[0];

                    foreach (DataRow dr in CustomerDataTable.Rows)
                    {
                        lstCustomers.Add(new Customer
                        {
                            CustomerId = dr["Customer_ID"].ToString(),
                            CustomerName = dr["Customer_Name"].ToString(),
                            Address = dr["Address"].ToString(),
                            DOB = Convert.ToDateTime(dr["DOB"].ToString()).Date,
                            Salary = Convert.ToDouble(dr["Salary"].ToString())
                        });
                    }
                }
                else
                {
                    foreach (DataRow dr in CustomerDataTable.Rows)
                    {
                        lstCustomers.Add(new Customer
                        {
                            CustomerId = dr["Customer_ID"].ToString(),
                            CustomerName = dr["Customer_Name"].ToString(),
                            Address = dr["Address"].ToString(),
                            DOB = Convert.ToDateTime(dr["DOB"].ToString()).Date,
                            Salary = Convert.ToDouble(dr["Salary"].ToString())
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                connection.Close();
                connection = null;
            }
            return lstCustomers;
        }

        private void ClearExistingRows()
        {
            if (CustomerDataTable != null)
            {
                foreach (DataRow row in CustomerDataTable.Rows)
                {
                    row.Delete();
                }
                CustomerDataTable.AcceptChanges();
            }
        }

        public Customer GetCustomerDS(string customerId)
        {
            Customer customer = null;
            if (CustomerDataTable.Rows.Count > 0)
            {
                var myRow = CustomerDataTable.Select("Customer_ID='" + customerId + "'").First();

                customer = new Customer
                {
                    CustomerId = myRow["Customer_ID"].ToString(),
                    CustomerName = myRow["Customer_Name"].ToString(),
                    Address = myRow["Address"].ToString(),
                    DOB = Convert.ToDateTime(myRow["DOB"].ToString()).Date,
                    Salary = Convert.ToDouble(myRow["Salary"].ToString())
                };

                return customer;
            }
            return null;
        }

        public int InsertCustomerDS(Customer customer)
        {   
            try
            {
                var maxCustId = CustomerDataTable.Compute("max([Customer_ID])", string.Empty);

                DataRow row = CustomerDataSet.Tables[0].NewRow();

                row["Customer_ID"] = "C" + (Convert.ToInt32(maxCustId.ToString().Substring(1)) + 1).ToString();
                row["Customer_Name"] = customer.CustomerName;
                row["Address"] = customer.Address;
                row["DOB"] = customer.DOB.Date;
                row["Salary"] = customer.Salary;
                CustomerDataTable.Rows.Add(row);
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {   
            }
            return 1;
        }

        public int UpdateCustomerDS(Customer customer)
        {
            try
            {
                var row = CustomerDataTable.Select("Customer_ID='" + customer.CustomerId + "'").First();
                
                row["Customer_Name"] = customer.CustomerName;
                row["Address"] = customer.Address;
                row["DOB"] = customer.DOB.Date;
                row["Salary"] = customer.Salary;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {
            }
            return 1;
        }

        public int DeleteCustomerDS(string customerID)
        {
            try
            {
                CustomerDataTable.Rows.Remove(CustomerDataTable.Select("Customer_ID='" + customerID + "'").First());
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
            finally
            {
            }
            return 1;
        }
    }
}