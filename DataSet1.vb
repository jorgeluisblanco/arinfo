Partial Class DataSet1
    Partial Class DataTable1DataTable

        Private Sub DataTable1DataTable_DataTable1RowChanging(ByVal sender As System.Object, ByVal e As DataTable1RowChangeEvent) Handles Me.DataTable1RowChanging

        End Sub

        Private Sub DataTable1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DataColumn6Column.ColumnName) Then
                'Agregar código de usuarioNTIDADD aquí
            End If

        End Sub

    End Class

End Class
