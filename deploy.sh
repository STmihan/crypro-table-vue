npm run build
cd dist || exit

git init
git remote add origin https://github.com/STmihan/crypro-table-vue.git

git branch -m master site
git add .
git commit -m 'deploy'

git push -f origin site

cd ..