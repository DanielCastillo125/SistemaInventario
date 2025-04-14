<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Me.btnProductos = New System.Windows.Forms.Button()
        Me.btnMovimientos = New System.Windows.Forms.Button()
        Me.btnReportes = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblBienvenida = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnProductos
        '
        Me.btnProductos.AutoSize = True
        Me.btnProductos.Location = New System.Drawing.Point(76, 214)
        Me.btnProductos.Name = "btnProductos"
        Me.btnProductos.Size = New System.Drawing.Size(139, 23)
        Me.btnProductos.TabIndex = 1
        Me.btnProductos.Text = "Mantenimiento Productos" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnProductos.UseVisualStyleBackColor = True
        '
        'btnMovimientos
        '
        Me.btnMovimientos.AutoSize = True
        Me.btnMovimientos.Location = New System.Drawing.Point(354, 214)
        Me.btnMovimientos.Name = "btnMovimientos"
        Me.btnMovimientos.Size = New System.Drawing.Size(126, 23)
        Me.btnMovimientos.TabIndex = 2
        Me.btnMovimientos.Text = "Movimientos Inventario" & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnMovimientos.UseVisualStyleBackColor = True
        '
        'btnReportes
        '
        Me.btnReportes.Location = New System.Drawing.Point(645, 214)
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Size = New System.Drawing.Size(75, 23)
        Me.btnReportes.TabIndex = 3
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.SistemaInventario_PT_M.My.Resources.Resources.eric_prouzet_d_1zXZmbAWc_unsplash
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(0, -5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(288, 455)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.SistemaInventario_PT_M.My.Resources.Resources.ashley_28b8xlTT5t4_unsplash
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(283, -5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(274, 455)
        Me.PictureBox2.TabIndex = 6
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.SistemaInventario_PT_M.My.Resources.Resources.scott_graham_5fNmWej4tAA_unsplash
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(555, -5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(247, 455)
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = False
        '
        'lblBienvenida
        '
        Me.lblBienvenida.AutoSize = True
        Me.lblBienvenida.Location = New System.Drawing.Point(370, 22)
        Me.lblBienvenida.Name = "lblBienvenida"
        Me.lblBienvenida.Size = New System.Drawing.Size(0, 13)
        Me.lblBienvenida.TabIndex = 8
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblBienvenida)
        Me.Controls.Add(Me.btnReportes)
        Me.Controls.Add(Me.btnMovimientos)
        Me.Controls.Add(Me.btnProductos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox3)
        Me.Name = "FrmPrincipal"
        Me.Text = "frmPrincipal"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnProductos As Button
    Friend WithEvents btnMovimientos As Button
    Friend WithEvents btnReportes As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblBienvenida As Label
End Class
