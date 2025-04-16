import React, { useState } from "react";
import { EntertainerDetails } from "../types/EntertainerDetails";

const usStates = [
  "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
  "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
  "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
  "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
  "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
];

interface Props {
  initialData?: Partial<EntertainerDetails>;
  onSubmit: (data: Partial<EntertainerDetails>) => void;
}

const requiredFields = ["entStageName", "entSsn", "entEmailAddress", "dateEntered"];

const EntertainerForm: React.FC<Props> = ({ initialData = {}, onSubmit }) => {
  const [formData, setFormData] = useState<Partial<EntertainerDetails>>(initialData);
  const [errors, setErrors] = useState<string[]>([]);

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    const missing = requiredFields.filter((field) => !formData[field as keyof EntertainerDetails]?.toString().trim());

    if (missing.length > 0) {
      setErrors(missing);
      return;
    }

    setErrors([]);
    onSubmit(formData);
  };

  return (
    <form onSubmit={handleSubmit} className="mb-4">
      {[
        { name: "entStageName", label: "Stage Name" },
        { name: "entSsn", label: "SSN" },
        { name: "entStreetAddress", label: "Street Address" },
        { name: "entCity", label: "City" },
        { name: "entState", label: "State" },
        { name: "entZipCode", label: "Zip Code" },
        { name: "entPhoneNumber", label: "Phone Number" },
        { name: "entWebPage", label: "Web Page" },
        { name: "entEmailAddress", label: "Email Address" },
        { name: "dateEntered", label: "Date Entered" },
      ].map(({ name, label }) => (
        <div className="mb-3" key={name}>
          <label className="form-label">{label}</label>
          { name === "entState" ? (
            <select
              className={`form-select ${errors.includes(name) ? "is-invalid" : ""}`}
              name={name}
              value={formData.entState || ""}
              onChange={handleChange}
            >
              <option value="">Select a state</option>
              {usStates.map((abbr) => (
                <option key={abbr} value={abbr}>
                  {abbr}
                </option>
              ))}
            </select>
          ) : (
            <input
              type="text"
              className={`form-control ${errors.includes(name) ? "is-invalid" : ""}`}
              name={name}
              value={formData[name as keyof EntertainerDetails] || ""}
              onChange={handleChange}
              disabled={name === "dateEntered" && !!initialData.dateEntered}
            />
          )}
          {errors.includes(name) && (
            <div className="invalid-feedback">{label} is required.</div>
          )}
        </div>
      ))}

      <button type="submit" className="btn btn-success">
        Save
      </button>
    </form>
  );
};

export default EntertainerForm;