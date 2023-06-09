Class Form1
    Private Sub KodeLostFocusListener() Handles Txttransaksi.LostFocus
        If Txttransaksi.Text.Trim() Is String.Empty Then
            MsgBox("Kode Tidak Boleh Kosong", Title:="Error")
        End If
    End Sub

    Private Sub KriteriaChangedListener(sender As RadioButton, e As EventArgs) Handles RbBebek.CheckedChanged, Rbsport.CheckedChanged
        If sender.Checked Then
            Cbjenis.ResetText()
            Cbjenis.Items.Clear()
            If sender Is Rbsport Then
                Cbjenis.Items.Add("MegaPro")
                Cbjenis.Items.Add("Tiger")
            Else
                Cbjenis.Items.Add("Supra Fit")
                Cbjenis.Items.Add("Supra X")
            End If
        End If
    End Sub

    Private Sub JenisChangedListener() Handles Cbjenis.TextChanged
        If Cbjenis.Text.Trim() Is String.Empty Then
            Txtharga.ResetText()
            Txtdiscount.ResetText()
            Txtsubharga.ResetText()
            Txtpajak.ResetText()
            Txttotalharga.ResetText()
        Else
            Dim harga, discount, subtotal, pajak, total As Double

            harga = IIf(Cbjenis.Text.Trim() = "MegaPro", 26, IIf(Cbjenis.Text.Trim() = "Tiger", 24, IIf(Cbjenis.Text.Trim() = "Supra Fit", 10, 15))) * 1000000
            discount = harga * 0.05
            subtotal = harga - discount
            pajak = subtotal * 0.1
            total = subtotal + pajak

            Txtharga.Text = FormatCurrency(harga, 0)
            Txtdiscount.Text = FormatCurrency(discount, 0)
            Txtsubharga.Text = FormatCurrency(subtotal, 0)
            Txtpajak.Text = FormatCurrency(pajak, 0)
            Txttotalharga.Text = FormatCurrency(total, 0)
        End If
    End Sub

    Private Sub BaruClickListener(sender As Object, e As EventArgs) Handles btBaru.Click
        Txttransaksi.ResetText()
        Txtnama.ResetText()
        Txtalamat.ResetText()
        Dttanggal.Value = Date.Now()
        Rbsport.Select()
        Cbjenis.ResetText()
        Txttransaksi.Focus()
    End Sub

    Private Sub KeluarClickListener(sender As Object, e As EventArgs) Handles btKeluar.Click
        Close()
    End Sub
End Class