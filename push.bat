set /p msg="Commit Message: "
git status
git add *
git commit -m %msg%
git push
PAUSE