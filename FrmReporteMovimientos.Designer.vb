<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReporteMovimientos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dtpDesde = New System.Windows.Forms.DateTimePicker()
        Me.dtpHasta = New System.Windows.Forms.DateTimePicker()
        Me.cmbProducto = New System.Windows.Forms.ComboBox()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.lblGuion = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtpDesde
        '
        Me.dtpDesde.Location = New System.Drawing.Point(40, 11)
        Me.dtpDesde.Name = "dtpDesde"
        Me.dtpDesde.Size = New System.Drawing.Size(200, 20)
        Me.dtpDesde.TabIndex = 0
        '
        'dtpHasta
        '
        Me.dtpHasta.Location = New System.Drawing.Point(262, 11)
        Me.dtpHasta.Name = "dtpHasta"
        Me.dtpHasta.Size = New System.Drawing.Size(200, 20)
        Me.dtpHasta.TabIndex = 1
        '
        'cmbProducto
        '
        Me.cmbProducto.FormattingEnabled = True
        Me.cmbProducto.Location = New System.Drawing.Point(542, 10)
        Me.cmbProducto.Name = "cmbProducto"
        Me.cmbProducto.Size = New System.Drawing.Size(121, 21)
        Me.cmbProducto.TabIndex = 2
        '
        'btnGenerar
        '
        Me.btnGenerar.Location = New System.Drawing.Point(713, 9)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(75, 23)
        Me.btnGenerar.TabIndex = 3
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Location = New System.Drawing.Point(21, 50)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(767, 388)
        Me.ReportViewer1.TabIndex = 4
        '
        'lblGuion
        '
        Me.lblGuion.AutoSize = True
        Me.lblGuion.Location = New System.Drawing.Point(246, 14)
        Me.lblGuion.Name = "lblGuion"
        Me.lblGuion.Size = New System.Drawing.Size(10, 13)
        Me.lblGuion.TabIndex = 5
        Me.lblGuion.Text = "-"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(483, 14)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(53, 13)
        Me.lblProducto.TabIndex = 6
        Me.lblProducto.Text = "Producto:"
        '
        'FrmReporteMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblProducto)
        Me.Controls.Add(Me.lblGuion)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnGenerar)
        Me.Controls.Add(Me.cmbProducto)
        Me.Controls.Add(Me.dtpHasta)
        Me.Controls.Add(Me.dtpDesde)
        Me.Name = "FrmReporteMovimientos"
        Me.Text = "FrmReporteMovimientos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpDesde As DateTimePicker
    Friend WithEvents dtpHasta As DateTimePicker
    Friend WithEvents cmbProducto As ComboBox
    Friend WithEvents btnGenerar As Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents lblGuion As Label
    Friend WithEvents lblProducto As Label
End Class
