<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="{0}">
        <{0}>
            <xsl:apply-templates select="Category">
                <xsl:sort select="@Name" data-type="text" order="ascending" />
            </xsl:apply-templates>
        </{0}>
    </xsl:template>
    <xsl:template match="Category">
        <xsl:element name="Category">
            <xsl:attribute name="Name">
                <xsl:value-of select="@Name" />
            </xsl:attribute>
            <xsl:apply-templates select="Key">
                <xsl:sort select="@Name" data-type="text" order="ascending" />
            </xsl:apply-templates>
        </xsl:element>
    </xsl:template>
    <xsl:template match="Key">
        <xsl:copy-of select="current()" />
    </xsl:template>
</xsl:stylesheet>
