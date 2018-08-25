<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:template match="/">
        <html> <body>
            <h1 style="background-color: blue; color: white; font-size: 18pt; text-align: center">
                Persons XML
            </h1>
            <table border="1">
                <tr style="font-size: 12pt; font-family: verdana; font-weight: bold">
                    <td style="text-align: center">Name</td>
                    <td style="text-align: center">Credential</td>
                    <td style="text-align: center">Phone</td>
                    <td style="text-align: center">Category</td>
                </tr>
                <xsl:for-each select="Persons/Person">
                    <tr style="font-size: 12pt; font-family: verdana">
                        <td><xsl:value-of select="Name/First"/>&#160;<xsl:value-of select="Name/Last"/>&#160;</td>
                        <td>Id: <xsl:value-of select="Credential/Id"/>&#160;Password: <xsl:value-of select="Credential/Password"/>&#160;</td>
                        <td>Work:<xsl:value-of select="Phone/Work"/>&#160;Cell: <xsl:value-of select="Phone/Cell"/>&#160;</td>
                        <td><xsl:value-of select="Category"/></td>
                    </tr>
                </xsl:for-each>
            </table>
        </body> </html>
    </xsl:template>
</xsl:stylesheet>
