import React from "react";
import { useNavigate } from "react-router-dom";

interface BackButtonProps {
  navigation?: () => void;
}

const BackButton: React.FC<BackButtonProps> = ({ navigation }) => {
  const navigate = useNavigate();

  return (
    <button className="btn btn-outline-secondary mb-3" onClick={navigation ?? (() => navigate(-1))}>
      &larr; Back
    </button>
  );
};

export default BackButton;