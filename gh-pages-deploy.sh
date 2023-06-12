#!/usr/bin/env sh

set -e

# set vite config's app base and outDir to github pages repo (by uncommenting the appropriate lines)
sed -i.bu '/base/s/^\/\///g' Client/vite.config.ts
sed -i.bu '/outDir/s/^\/\///g' Client/vite.config.ts
sed -i.bu '/emptyOutDir/s/^\/\///g' Client/vite.config.ts

# build the app
npm run build

#revert vite config's app base and outDir to / and dist respectively (by uncommenting the appropriate lines)
sed -i.bu '/base/s/^/\/\//' Client/vite.config.ts
sed -i.bu '/outDir/s/^/\/\//' Client/vite.config.ts
sed -i.bu '/emptyOutDir/s/^/\/\//' Client/vite.config.ts

# remove backup file
rm Client/*.bu

# rm -f ../analytics-gh-pages/*
# cp -r Client/dist/* ../analytics-gh-pages/

# cd -
