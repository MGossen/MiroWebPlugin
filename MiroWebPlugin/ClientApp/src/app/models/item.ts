export interface CreatedBy {
  id: string;
  type: string;
}

export interface Data {
  content: string;
  shape: string;
  title: string;
}

export interface Geometry {
  width: number;
  height: number;
}

export interface Item {
  id: string;
  type: string;
  links: Links;
  createdAt: string;
  createdBy: CreatedBy;
  data: Data;
  geometry: Geometry;
  modifiedAt: string;
  modifiedBy: ModifiedBy;
  position: Position;
  style: Style;
  parent: Parent;
}

export interface Links {
  self: string;
}

export interface ModifiedBy {
  id: string;
  type: string;
}

export interface Position {
  x: number;
  y: number;
  origin: string;
  relativeTo: string;
}

export interface Style {
  fillColor: string;
  fillOpacity: string;
  fontFamily: string;
  fontSize: string;
  borderColor: string;
  borderWidth: string;
  borderOpacity: string;
  borderStyle: string;
  textAlign: string;
  textAlignVertical: string;
  color: string;
}

export interface Parent {
  id: string;
}
