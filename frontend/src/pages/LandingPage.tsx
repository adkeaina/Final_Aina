import { Link } from "react-router-dom";

const LandingPage: React.FC = () => {
  return (
    <div className="container text-center mt-5">
      <div className="row justify-content-center">
        <div className="col-md-8">
          <h1 className="display-4 mb-4">Welcome to the Entertainment Agency</h1>
          <p className="lead mb-5">
            Discover and manage talented entertainers. Book shows, view details, and more.
          </p>
          <Link to="/entertainers" className="btn btn-primary btn-lg">
            View Entertainers
          </Link>
        </div>
      </div>
    </div>
  );
};

export default LandingPage;