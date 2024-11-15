namespace POS.Utilities.Static
{
    public class ExcelColumnNames
    {
        public static List<TableColumn> GetColumns(IEnumerable<(string ColumnName, string PropertyName)> columnsProperty)
        {
            var columns = new List<TableColumn>();
            foreach (var (ColumnName, PropertyName) in columnsProperty)
            {
                var column = new TableColumn()
                {
                    Label = ColumnName,
                    PropertyName = PropertyName,
                };
                columns.Add(column);
            }
            return columns;

        }

        #region ColumnsCategories
        public static List<(string ColumnName, string PropertyName)> GetColumnsCategories()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE","Name"),
                ("DESCRIPCION","Description"),
                ("FECHA DE CREACION","AuditCreateDate"),
                ("ESTADO","stateCategory"),

            };

            return columnsProperties;
        }

        #endregion

        #region ColumnsProviders
        public static List<(string ColumnName, string PropertyName)> GetColumnsProviders()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE","Name"),
                ("EMAIL","Email"),
                ("TIPO DE DOCUMENTO","DocumentType"),
                ("NUMERO DE DOCUMENTO","DocumentNumber"),
                ("DIRECCION","Address"),
                ("TELEFONO","Phone"),
                 ("FECHA DE CREACION","AuditCreateDate"),
                  ("ESTADO","stateCategory")

            };

            return columnsProperties;
        }

        #endregion

        #region ColumnWarehouses
        public static List<(string ColumnName, string PropertyName)> GetColumnsWarehouses()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("NOMBRE","Name"),
                ("FECHA DE CREACION","AuditCreateDate"),
                ("ESTADO","stateCategory"),
             

            };

            return columnsProperties;
        }
        #endregion

        #region ColumnWarehouses
        public static List<(string ColumnName, string PropertyName)> GetColumnsProducts()
        {
            var columnsProperties = new List<(string ColumnName, string PropertyName)>
            {
                ("CÓDIGO","Code"),
                ("NOMBRE","Name"),
                ("STOCK MINIMO","StockMin"),
                ("STOCK MAXIMO","StockMax"),
                ("PRECIO DE VENTA","UnitsalePrice"),
                ("CATEGORIA","Category"),
                ("FECHA DE CREACION","AuditCreateDate"),
                ("ESTADO","StateProduct"),


            };

            return columnsProperties;
        }
        #endregion
    }
}