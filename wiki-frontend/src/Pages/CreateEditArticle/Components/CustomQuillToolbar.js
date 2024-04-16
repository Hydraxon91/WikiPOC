import React from 'react';
import { Quill } from "react-quill";
import "react-quill/dist/quill.snow.css";

const CustomQuillToolbar = ({ togglePopupVisibility }) => (
  <div id="toolbar">
    <button className="ql-bold" />
    <button className="ql-italic" />
    <button className="ql-underline" />
    <button className="ql-strike" />
    <button className="ql-script" value="super" />
    <button className="ql-script" value="sub" />
    <button className="ql-blockquote" />
    <button className="ql-link" />
    <button className="ql-image" />
    <button className="ql-video" />
    <button className="ql-formula" />
    <button className="ql-code-block" />
    <button className="ql-clean" />
    <button className="ql-custom" onClick={togglePopupVisibility}>
      Insert Custom HTML
    </button>
  </div>
);

export default CustomQuillToolbar;
