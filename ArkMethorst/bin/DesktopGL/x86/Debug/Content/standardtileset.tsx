<?xml version="1.0" encoding="UTF-8"?>
<tileset version="1.5" tiledversion="1.5.0" name="TiledIcons" tilewidth="16" tileheight="16" tilecount="1024" columns="32">
 <image source="StandardTilesetIcons.png" width="512" height="512"/>
 <tile id="0" type="SolidCollision"/>
 <tile id="1" type="BreakableCollision"/>
 <tile id="2" type="CloudCollision"/>
 <tile id="3" type="OneWayCollision"/>
 <tile id="32" type="Water"/>
 <tile id="33" type="IceCollision"/>
 <tile id="64" type="EndOfLevel">
  <properties>
   <property name="NextLevel" value=""/>
  </properties>
 </tile>
 <tile id="68" type="Checkpoint">
  <properties>
   <property name="Visible" type="bool" value="true"/>
  </properties>
 </tile>
 <tile id="96" type="Ladder"/>
</tileset>
