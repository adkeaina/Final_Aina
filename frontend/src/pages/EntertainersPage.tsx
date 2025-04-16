import { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Entertainer } from "../types/Entertainer";
import { fetchEntertainers } from "../api/EntertainmentAPI";

const EntertainersPage: React.FC = () => {
  const [entertainers, setEntertainers] = useState<Entertainer[]>([]);
  const navigate = useNavigate();

  useEffect(() => {
    const loadEntertainers = async () => {
      try {
        const data = await fetchEntertainers();
        setEntertainers(data);
      } catch (err) {
        console.error("Failed to fetch entertainers:", err);
      }
    };

    loadEntertainers();
  }, []);

  if (entertainers === null) {
    return <div className="container mt-4">Loading entertainers...</div>;
  }

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Entertainers</h2>
      <table className="table table-striped">
        <thead>
          <tr>
            <th>Stage Name</th>
            <th>Bookings Count</th>
            <th>Last Booking Date</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {entertainers.map((ent) => (
            <tr key={ent.entertainerId}>
              <td>{ent.entStageName}</td>
              <td>{ent.bookingsCount}</td>
              <td>{ent.lastBookingDate ?? "N/A"}</td>
              <td>
                <button
                  className="btn btn-sm btn-outline-primary"
                  onClick={() => navigate(`/entertainers/${ent.entertainerId}`)}
                >
                  Details
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <div className="text-end">
        <Link to="/entertainers/new" className="btn btn-success">
          Add Entertainer
        </Link>
      </div>
    </div>
  );
};

export default EntertainersPage;