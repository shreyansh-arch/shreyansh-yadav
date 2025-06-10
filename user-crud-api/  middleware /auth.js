const auth = (req, res, next) => {
  const token = req.headers['authorization'];
  if (token === 'Bearer secrettoken') {
    next();
  } else {
    res.status(403).json({ message: 'Unauthorized' });
  }
};

module.exports = auth;
